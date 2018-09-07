// 系統錯誤視窗
function errorModal(message) {
    $.unblockUI();
    swal({
        title: "操作失敗",
        html: "請洽系統管理員!<br\>" + (!message ? "" : message.replace(/^.*?<body[^>]*>(.*?)<\/body>.*?$/i, "$1")),
        type: "error",
        //timer: 3000,
        confirmButtonText: "確定",
        width: (!message ? 500 : 1200)
    }).then(
        function (result) { }
    );
}

// 儲存時呼叫的function
// 為了避免CSRF攻擊, 會取得RequestVerificationToken
// 先上傳檔案, 再寫入DB
function ajaxUpload(saveUrl, data, uploadUrl, formdata) {
    //alert(JSON.stringify(data));

    $.ajax({
        url: saveUrl,
        type: "POST",
        dataType: 'json',
        data: {
            __RequestVerificationToken: $('[name=__RequestVerificationToken]').val(),
            form: data
        },
        beforeSend: function () {
            blockUI();
        },
        success: function (data) {
            $.ajax({
                url: uploadUrl,
                type: "POST",
                data: formdata,
                contentType: false,
                processData: false,
                success: function (response) {
                    //alert(response);
                    
                    ajaxResponse("儲存", data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    errorModal(xhr.responseText);
                }
            });



        },
        error: function (xhr, ajaxOptions, thrownError) {
            errorModal(xhr.responseText);
        },
        complete: function () {
            $.unblockUI();
        }
    });
}


// 儲存時呼叫的function
// 為了避免CSRF攻擊, 會取得RequestVerificationToken
// 第二個參數為畫面資料, 未傳入時預設抓[name=form]去serialize
function ajaxSave(saveUrl, data) {
    //alert(JSON.stringify(data));

    $.ajax({
        url: saveUrl,
        type: "POST",
        dataType: 'json',
        data: {
            __RequestVerificationToken: $('[name=__RequestVerificationToken]').val(),
            form: data
        },
        beforeSend: function () {
            blockUI();
        },
        success: function (data) {
            ajaxResponse("儲存", data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            errorModal(xhr.responseText);
        },
        complete: function () {
            $.unblockUI();
        }
    });
}

// ajax回覆訊息
function ajaxResponse(actionTypeText, data, message, elapse) {
    if (!data.Success) {
        $(".validation-summary-errors ul li").remove();
        $.each(data.Message, function (index, item) {
            $(".validation-summary-errors ul").append($("<li>").text(item));
        });
    } else {
        swal({
            title: "完成",
            html: !message ? actionTypeText + "成功!" : message,
            type: "success",
            timer: !elapse ? 2000 : elapse,
            showConfirmButton: false
        }).then((result) => {
            if (result.dismiss === swal.DismissReason.timer) {
                if (!data.Link) {
                    location.reload();
                } else {
                    location.href = data.Link;
                }
            }
        });
    }
}


// 跳至前一頁
function previousPage(link) {
    location.href = document.referrer;
}

// 刪除確認視窗function
// 會先跳出刪除確認
// 若驗證不成功, 會跳出錯誤訊息(顯示後端controller message)
// 若刪除不成功, 會跳出系統錯誤訊息
function confirmDialog(path, deleteKey, message) {
    var data = {};
    data.__RequestVerificationToken = $('[name=__RequestVerificationToken]').val();
    data.id = deleteKey;

    // alert(path);
    // alert(JSON.stringify(data));

    swal({
        title: '確認視窗',
        text: "確認要" + (!!message ? message : "刪除") + "該筆資料?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        confirmButtonText: '確認',
        confirmButtonClass: 'btn btn-success',
        cancelButtonColor: '#d33',
        cancelButtonText: '否',
        cancelButtonClass: 'btn btn-danger'
    }).then(
        function (isConfirm) {
            $.blockUI({ message: "" });
            $.ajax({
                url: path,
                type: "DELETE",
                data: data,
                success: function (data) {
                    ajaxResponse((!!message ? message : "刪除"), data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    errorModal(xhr.responseText);
                },
                complete: function () {
                    $.unblockUI();
                }
            });
        },
        function (dismiss) {
            if (dismiss === 'cancel') {
                return;
            }
        }
    );
}


// 確認視窗function
// 會先跳出刪除確認
// 若驗證不成功, 會跳出錯誤訊息(顯示後端controller message)
// 若刪除不成功, 會跳出系統錯誤訊息
function confirm(path, data, message) {
    // alert(path);
    data.__RequestVerificationToken = $('[name=__RequestVerificationToken]').val();

    swal({
        title: '確認視窗',
        text: "確認要" + message + "該筆資料?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        confirmButtonText: '確認',
        confirmButtonClass: 'btn btn-success',
        cancelButtonColor: '#d33',
        cancelButtonText: '否',
        cancelButtonClass: 'btn btn-danger'
    }).then(
        function (isConfirm) {
            $.blockUI({ message: "" });
            $.ajax({
                url: path,
                type: "POST",
                data: data,
                success: function (data) {
                    ajaxResponse(message, data);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    errorModal(xhr.responseText);
                },
                complete: function () {
                    $.unblockUI();
                }
            });
        },
        function (dismiss) {
            if (dismiss === 'cancel') {
                return;
            }
        }
    );
}


//這裡是設定session timeout倒數時間
function setTimer(seconds) {

    var interval = setInterval(function () {
        if (seconds > 0) {
            seconds--;
            //if (seconds % 3 == 0 ) alert(seconds);
            // console.log(seconds);
            //如果timeou就提示訊息登出
            if (seconds === 0) {
                swal({
                    title: "登出",
                    html: "<font color='red'>您的閒置時間過久!<br>已被系統登出，請重新登入!</font>",
                    type: "warning",
                    timer: 3000,
                    showConfirmButton: false
                }).then(
                    function (result) { },
                    function (dismiss) {
                        if (dismiss === 'timer') {
                            $('#logoutForm').submit();
                        }
                    }
                );
            }

        } else { //倒數時間已結束，將該使用者登出導向登入頁
            clearInterval(interval); //清除此倒數方法
        }
    }, 1000);//設定每秒鐘執行

    return interval;
}

// 編輯、刪除 button
// editPath : 編輯路徑
// deletePath : 刪除路徑 
// id : key
function editDeleteButton(editPath, deletePath, id) {
    //alert(buttons);
    return editButton(editPath, id) + deleteButton(deletePath, id);
}


// 編輯 button
// editPath : 編輯路徑
// id : key
function editButton(editPath, id) {
    var button = "<button class='btn btn-primary btn-sm' onClick=\"location.href='" + editPath + id + "'\"><i class='fa fa-edit'></i>編輯</button> ";

    //alert(buttons);
    return button;
}

// 刪除 button
// deletePath : 刪除路徑 
// id : key
function deleteButton(deletePath, id) {
    var button = "<button class='btn btn-danger btn-sm' onClick='confirmDialog(\"" + deletePath + "\", \"" + id + "\")'><i class='fa fa-remove'></i>刪除</button> ";

    //alert(button);
    return button;
}

// 放映 button
function projectButton(editPath, id) {
    var button = "<button class='btn btn-info btn-sm' onClick=\"location.href='" + editPath + id + "'\"><i class='fa fa-edit'></i>播放</button> ";

    //alert(buttons);
    return button;
}

// 列印 button
// editPath : 列印路徑
// id : key
function printButton(printPath, id) {
    var button = "<button class='btn btn-info btn-sm' onClick=\"window.open('" + printPath + "?key=" + id + "', '_blank') \"><i class='fa fa-edit'></i>列印</button> ";
    //alert(buttons);
    return button;
}

function errorMessage(message) {
    swal({
        title: "錯誤",
        text: message,
        type: "error",
        confirmButtonText: "確定",
    });
}

function warningMessage(message) {
    swal({
        title: "警示",
        text: message,
        type: "warning",
        confirmButtonText: "確定",
    });
}

function exportExcel(path, model, fileName) {
    //alert(JSON.stringify(model));
    blockUI();
    axios.get(path, {
        params: model,
        method: 'get',
        withCredentials: true,
        responseType: 'blob',
        headers: {
            'Accept': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        },
    }).then((response) => {
        download(response.data, fileName);
        $.unblockUI();
    });
}


// 上傳檔案
function uploadFile(file) {
    var reader = new FileReader();
    var deferred = $.Deferred();

    reader.onload = function (event) {
        deferred.resolve(event.target.result);
    };

    reader.onerror = function () {
        deferred.reject(this);
    };

    if (/^image/.test(file.type)) {
        reader.readAsDataURL(file);
    } else {
        reader.readAsText(file);
    }

    return deferred.promise();
}