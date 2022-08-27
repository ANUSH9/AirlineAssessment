//// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//// for details on configuring this project to bundle and minify static web assets.

//// Write your JavaScript code.




//$(function () {
//    var PlaceHolderElement = $('PlaceHolderHere');
//    $('button[data-toggle="ajax-model"]').click(function (event) {
//        var url = $(this).data('url');
//        var decoderUrl = decodeURIComponent(url);
           
//    })
//})
//PlaceHolderElement.on('click', '[data-save="model"]', function(event))
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script>
$(document).ready(function(){
  $("Delete").click(function(){
    $.get("demo_test.asp", function(data, status){
      alert("Data: " + data + "\nStatus: " + status);
    });
  });
});
</script>
