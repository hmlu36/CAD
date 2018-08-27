Vue.component("v-post", {
    props: ['post'],
    template: [
        "<div class='col-lg-4 col-sm-6 text-center mb-4'>                                                                          ",
        "     <div class='thumbnail'>                                                                                              ",
        "         <img class='img-fluid d-block mx-auto col-6' v-bind:src='\"/images/Post/\" + post.Path' v-on:click='popMessage(post)' alt=' '>  ",
        "     </div>                                                                                                              ",
        "     <p>{{post.Name}}<br/>{{post.Mold}}</p>                                                                              ",
        "     <p style='white-space: pre'>{{post.Description}}</p>                                                                ",
        "</div>                                                                                                                    "
    ].join(""),
    methods: {
        popMessage(post) {
            let $element =
            '<div class="article-read text-left">                                                                                 ' +
            '    <div class="article-read-inner">                                                                                 ' +
            '        <div class="article-back">                                                                                   ' +
            '            <a class="btn btn-outline-primary"><i class="ion ion-chevron-left"></i> Back</a>                         ' +
            '        </div>                                                                                                       ' +
            '       <div class="tab">                                                                                             ' +
            '           <div class="d-flex justify-content-center">                                                               ' +
            '               <ul class="nav nav-tabs mb-4 justify-content-center">                                                 ' +
            '                   <li class="nav-item"><a class="nav-link" href="#Section1" data-toggle="tab">功能</a></li>         ' +
            '                   <li class="nav-item"><a class="nav-link" href="#Section2" data-toggle="tab">食譜</a></li>         ' +
            '                   <li class="nav-item"><a class="nav-link" href="#Section3" data-toggle="tab">設計</a></li>         ' +
            '                   <li class="nav-item"><a class="nav-link" href="#Section4" data-toggle="tab">故事</a></li>         ' +
            '                   <li class="nav-item"><a class="nav-link" href="#Section5" data-toggle="tab">規格</a></li>         ' +
            '               </ul>                                                                                                 ' +
            '           </div>                                                                                                    ' +
            '       </div>                                                                                                        ' +
            '       <div class="tab-content post-content">                                                                        ' +
            '           <div class="tab-pane" id="Section1">                                                                      ' +
            '               <div class="row my-4">                                                                                ' +
            '                   <div class="col-lg-8 text-right">                                                                 ' +
            '                       {FunctionPath}                                     ' +
            '                   </div>                                                                                            ' +
            '                   <div class="col-lg-4">                                                                            ' +
            '                       <h3>{FunctionTitle}</h3>                                                                      ' +
            '                       <p style="white-space: pre">{FunctionDescription}</p>                                         ' +
            '                   </div>                                                                                            ' +
            '               </div>                                                                                                ' +
            '           </div>                                                                                                    ' +
            '           <div class="tab-pane" id="Section2">                                                                      ' +
            '               <div class="row my-4">                                                                                ' +
            '                   <div class="col-lg-8 text-right">                                                                 ' +
            '                       {RecipePath}                                       ' +
            '                   </div>                                                                                            ' +
            '                   <div class="col-lg-4">                                                                            ' +
            '                       <h3>{RecipeTitle}</h3>                                                                        ' +
            '                       <p style="white-space: pre">{RecipeDescription}</p>                                           ' +
            '                   </div>                                                                                            ' +
            '               </div>                                                                                                ' +
            '           </div>                                                                                                    ' +
            '           <div class="tab-pane" id="Section3">                                                                      ' +
            '               <div class="row my-4">                                                                                ' +
            '                   <div class="col-lg-8 text-right">                                                                 ' +
            '                       {DesignPath}                                       ' +
            '                   </div>                                                                                            ' +
            '                   <div class="col-lg-4">                                                                            ' +
            '                       <h3>{DesignTitle}</h3>                                                                        ' +
            '                       <p style="white-space: pre">{DesignDescription}</p>                                           ' +
            '                   </div>                                                                                            ' +
            '               </div>                                                                                                ' +
            '           </div>                                                                                                    ' +
            '           <div class="tab-pane" id="Section4">                                                                      ' +
            '               <div class="row my-4">                                                                                ' +
            '                   <div class="col-lg-8 text-right">                                                                 ' +
            '                       {StoryPath}                                        ' +
            '                   </div>                                                                                            ' +
            '                   <div class="col-lg-4">                                                                            ' +
            '                       <h3>{StoryTitle}</h3>                                                                         ' +
            '                       <p style="white-space: pre">{StoryDescription}</p>                                            ' +
            '                   </div>                                                                                            ' +
            '               </div>                                                                                                ' +
            '           </div>                                                                                                    ' +
            '           <div class="tab-pane" id="Section5">                                                                      ' +
            '               <div class="row my-4">                                                                                ' +
            '                   <div class="col-lg-8 text-right">                                                                 ' +
            '                       {SpecPath}                                         ' +
            '                   </div>                                                                                            ' +
            '                   <div class="col-lg-4">                                                                            ' +
            '                       <h3>{SpecTitle}</h3>                                                                          ' +
            '                       <p style="white-space: pre">{SpecDescription}</p>                                             ' +
            '                   </div>                                                                                            ' +
            '               </div>                                                                                                ' +
            '           </div>                                                                                                    ' +
            '       </div>                                                                                                        ' +
            '    </div>                                                                                                           ' +
            '</div>                                                                                                               ' +
            '<script>$(".nav-tabs a[href=\'#Section1\']").tab("show"); </script>';


            let reg = /{([a-zA-Z0-9]+)}/g,
                res = [],
                element = $element;
            var tempData = "";
            while (match = reg.exec($element)) {
                tempData = post[match[1]];

                if (!tempData) {
                    tempData = '';
                } else if (match[1].includes('Path')) {
                    tempData = '<img class="img-fluid" src="/images/Post/' + tempData + '">';
                }

                element = element.replace('{' + match[1] + '}', tempData);
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
    }
});