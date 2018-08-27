$(function () {

    $("body").css("background-image", "url(images/background.jpg)");
    /*
    var width = $(window).width();
    var height = $(window).height();

    $.blockUI({
        //message: "<img src='images/" + (width > height ? "EUPA home.jpg" : "EUPA home-vertical.jpg") + "' style='width:auto ; height:100%;'/>",
        message: "<img src='images/Welcome.GIF' style='width:auto ; height:30%;'/>",
        css: {
            top: 0,
            left: 0,
            width: width,
            height: height,
            backgroundColor: '#F8E13B',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
        }
    });
    $(".navbar").hide();
    $(".header-area").hide();
    $(".container").hide();

    setTimeout(function () {
        $(".navbar").show();
        $(".header-area").show();
        $(".container").show();
        $.unblockUI();
    }, 3000);
    */

    init();
});

function init() {
    // navbar toggle使用
    $(".navbar-toggler").click(function () {
        /*
        var status = !$("#navbarResponsive").hasClass("show");
        console.log(status);
        if (status) {
            $(".navbar").addClass("bg-dark");
            $(".navbar").addClass("navbar-dark");
        } else {
            $(".navbar").removeClass("bg-dark");
            $(".navbar").removeClass("navbar-dark");
        }
        */

        $(".navbar").toggleClass("bg-dark");
        $(".navbar").toggleClass("navbar-dark");
    });

    //jQuery to collapse the navbar on scroll
    $(window).scroll(function () {
        if ($(".navbar").offset().top > 10) {
            $(".fixed-top").addClass("top-nav-collapse");
            $("#body").css("background-image", "none");
            $("body").css("background-image", "none");
        } else {
            $(".fixed-top").removeClass("top-nav-collapse");
            $("body").css("background-image", "url(images/background.jpg)");
            $("#body").css("background-image", "url(images/background.jpg)");
        }
    });

    //console.log(width);

    var topParameter = $(".navbar-nav").css('top').replace("px", "");
    topParameter = (topParameter === "auto") ? "80" : topParameter;
    // console.log(topParameter);

    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function () {
        if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');

            if (target.length) {
                $('html, body').animate({
                    scrollTop: (target.offset().top - topParameter)
                }, 1000, "easeInOutExpo");
                return false;
            }
        }
    });

    $("a.js-scroll-trigger").click(function () {
        $(".navbar").removeClass("bg-dark");
        $('.navbar-collapse').collapse('hide');
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $('body').scrollspy({
        target: '#mainNav',
        offset: Number(topParameter)
    });



    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content');

    allWells.hide();

    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        if (!$item.hasClass('disabled')) {
            navListItems.removeClass('btn-indigo').addClass('btn-default');
            $item.addClass('btn-indigo');
            allWells.hide();
            $target.show();
            $target.find('input:eq(0)').focus();
        }
    });

    $('div.setup-panel div a.btn-indigo').trigger('click');
}

new Vue({
    el: '.header-area',
    data: {
        /*
        sliders: [
            { "mold": "TSK-P103NBDQ.jpg" },
            { "mold": "TSK-2625ST.jpg" },
            { "mold": "TSK-2309BPZ.jpg" },
            { "mold": "TSK-2265GW.jpg" },
            { "mold": "TSK-2193W.jpg" },
            { "mold": "TSK-1837B.jpg" }
        ]
        */
        sliders: []
    },
    methods: {
        getCarousel() {
            axios.get('/Carousel')
                .then(response => {
                    // alert(JSON.stringify(response.data));
                    this.sliders = response.data;
                });
        },
        headerContent(slider) {
            // 彈跳視窗
            let $element =
                '<div class="article-read text-left">                                                                                 ' +
                '    <div class="article-read-inner">                                                                                 ' +
                '        <div class="article-back">                                                                                   ' +
                '            <a class="btn btn-outline-primary"><i class="ion ion-chevron-left"></i> Back</a>                         ' +
                '        </div>                                                                                                       ' +
                '    </div>                                                                                                           ' +
                '    <div class="w-100"><img src = "images/Carousel/{Path}" class="img-fluid" > </div> <br/><br/><br/><br/>           ' +
                '</div>                                                                                                               ';

            let reg = /{([a-zA-Z0-9]+)}/g,
                res = [],
                element = $element;
            while (match = reg.exec($element)) {
                element = element.replace('{' + match[1] + '}', slider[match[1]]);
            }

            $.blockUI({
                message: element,
                css: {
                    top: 0,
                    left: 0,
                    width: $(window).width(),
                    height: $(window).height(),
                    overflow: 'scroll',
                    cursor: 'default'
                }
            });

            $("nav").hide();

            $(".article-read").fadeIn();
            $(document).on("click", ".article-back .btn", function () {
                $(".article-read").fadeOut(function () {
                    $(".article-read").remove();
                    $("nav").show();
                    $.unblockUI();
                });
                return false;
            });
        }
    },
    created() {
        this.getCarousel();
    }
});

new Vue({
    el: '.container',
    data: {
        posts: [],
        page: [],
        categories: [],
        selectedCatetory: ""
        /*categories: [{ 'key': 'Coffee', 'value': '咖啡文化' },
                     { 'key': 'Cooking', 'value': '美食調理' },
                     { 'key': 'Food', 'value': '食物處理' },
                     { 'key': 'Gadgage', 'value': '居家幫手' }]*/
    },
    methods: {
        getData: function (category, page) {
            this.selectedCatetory = (!category ? this.selectedCatetory : category);
            TTS(!this.selectedCatetory ? this.categories[0].Code : this.selectedCatetory);
            //alert(this.selectedCatetory);
            axios.get('/PostGrid', {
                params: { Category: (!this.selectedCatetory ? this.categories[0].Code : this.selectedCatetory), Page: (!page ? 1 : page) }
            })
                .then(response => {
                    // alert(JSON.stringify(response.data));
                    this.page = response.data;
                    this.posts = this.page.Results;
                });
        },
        pageOnLoad: async function () {
            // 非同步，先取得所有類型，再取列表資料
            const [CategoryResponse] = await axios.all([axios.get('ProductCategories')]);
            this.categories = CategoryResponse.data;
            this.getData();
        }
    },
    created() {
        this.pageOnLoad();
        this.selectedCatetory = "";
    }
});


function TTS(word) {
    if ('speechSynthesis' in window && !!word) {
        alert(word);

        var msg = new SpeechSynthesisUtterance();
        var voices = window.speechSynthesis.getVoices();
        msg.voice = voices[0];
        msg.rate = 3 / 10;
        msg.pitch = 1;
        msg.text = "咖啡 美食";

        msg.onend = function (e) {
            console.log('Finished in ' + event.elapsedTime + ' seconds.');
        };

        speechSynthesis.speak(msg);
    }
}