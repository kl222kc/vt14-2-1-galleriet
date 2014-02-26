$(document).ready(function () {

    if ($('#UploadSuccess').is(':visible')) {
        $("#success").show("slow", function () {
            $(this).fadeOut(10000);
        });
    }

    $("#UploadSuccess").click(function () {
        $(this).fadeOut(2000);
    });

    var fileName = location.search.split("?img=")[1];
    
    $('#thumbnails img').each(function(i,ele){
        if ($(this).attr("src") == "Content/Images/Thumbnails/" + fileName) { 
            $(this).addClass("current"); 
        }
    }
    
)});
