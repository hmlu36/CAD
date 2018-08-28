$(function () {
    
    init();
    initSpeech();
});

function initSpeech() {
    if ('speechSynthesis' in window) {
        $('#speak').click(function () {
            var text = $('#message').val();
            var msg = new SpeechSynthesisUtterance();
            var voices = window.speechSynthesis.getVoices();
            msg.voice = voices[0];
            msg.rate = $('#rate').val() / 10;
            msg.pitch = $('#pitch').val();
            msg.text = text;
            /*
            msg.onend = function(e) {
              console.log('Finished in ' + event.elapsedTime + ' seconds.');
            };
            */

            speechSynthesis.speak(msg);
        })
    } else {
        $('#modal1').openModal();
    }
}


function init() {
    // navbar toggle使用
    $(".navbar-toggler").click(function () {
        $(".navbar").toggleClass("bg-dark");
        $(".navbar").toggleClass("navbar-dark");
    });

    //jQuery to collapse the navbar on scroll
    $(window).scroll(function () {
        if ($(".navbar").offset().top > 10) {
            $(".fixed-top").addClass("top-nav-collapse");
            //$("#body").css("background-image", "none");
            //$("body").css("background-image", "none");
        } else {
            $(".fixed-top").removeClass("top-nav-collapse");
            //$("body").css("background-color", "#5CB0F1");
            //$("#body").css("background-color", "#5CB0F1");
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
    el: '.container',
    data: {
        posts: [],
        page: [],
        categories: [],
        selectedCatetory: ""
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
            //const [CategoryResponse] = await axios.all([axios.get('ProductCategories')]);
            //this.categories = CategoryResponse.data;
            //this.getData();
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