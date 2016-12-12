/// <reference path="jquery-3.1.1.js" />
$(document).ready(function(){


    $(".modalbutton").click(function (event) {
        var url = $(this).attr("data-url");
        $("#myModal").on("shown.bs.modal", function () {

            $("iframe").attr("src", url + "/module?theme=4790");
            $("iframe").css("pointer-events", "auto");
            
            document.getElementById("iframediv").addEventListener("click", function (e) {
                alert("hello");
                e.preventDefault();
                return false;
            }, true);

        });
        $("#myModal").modal('show'); 
    })

    $(".participantModal").click(function (event) {
        var url = $(this).attr("data-url");
        $("#myModal").on("shown.bs.modal", function () {

            $("iframe").attr("src", url + "/module?theme=4790");
            //$("iframe").css("pointer-events", "none");

        });
        $("#myModal").modal('show');
    });
    


})