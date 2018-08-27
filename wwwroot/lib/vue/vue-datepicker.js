Vue.component('vue-datepicker', {
    template: '<input type="text" class="form-control" v-bind:value="value" v-on:blur="changeHandler" placeholder="yyyy/MM/dd" />',
    props: {
        value: String,
        minDate: {
            default: null,
            type: String
        },
        defaultDate: {
            default: 0,
            type: String
        }
    },
    mounted: function () {

        // 日期格式改為繁體中文
        let  vm = this;
        $(this.$el)
            .datepicker({
                dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
                dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"],
                monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
                monthNamesShort: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
                prevText: "上月",
                nextText: "次月",
                weekHeader: "週",
                minDate: this.minDate,
                dateFormat: "yy/mm/dd",
                onSelect: function (date) {
                    vm.$emit('input', date) //注意一下裡面的this是jquery對象的部份，所以定義一個vm變數代表vue的實體
                }
            });
        // 預設日期
        if (!!this.defaultDate) {
            $(this.$el).datepicker("setDate", this.defaultDate);
        }

        // 欄位原始帶入值(編輯用)
        if (!!this.value) {
            $(this.$el).val(this.value);
            $(this.$el).trigger("change");
        }
    },
    methods: {
        changeHandler: function (event) {
            if (!!this.minDate) {
                var startDate = moment().startOf('day').add(this.minDate, 'days');
                var inputDate = moment(event.target.value, 'YYYY/MM/DD').toDate();

                if (inputDate < startDate) {
                    swal({
                        title: "錯誤",
                        text: "請輸入日期不可小於最小區間",
                        type: "error",
                        confirmButtonText: "確定",
                    });

                    $(this.$el).val(startDate.format('YYYY/MM/DD'));
                }
            } else if (!!event.target.value && !isValidDate(event.target.value)) {
                swal({
                    title: "錯誤",
                    text: "請輸入正確日期格式",
                    type: "error",
                    confirmButtonText: "確定",
                });

                $(this.$el).val("");
            } else {
                this.$emit('input', event.target.value);
            }
        }
    },
    watch: {
        value: function (value) {
            $(this.$el).val(value);
        }
    },

    destroyed: function () {
        $(this.$el).datepicker('destroy');
    }
});