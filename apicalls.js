$(document).ready(function () {  
    $.ajax({  
        type: "GET",  
        url: "https://bilbixenapi.azurewebsites.net/produkter/get/bil",   
        success: function (data) {  
            var s = '<option value="-1">Vælg en type bil</option>';  
            for (var i = 0; i < data.length; i++) {  
                s += '<option value="' + data[i].produktId+ '">' + data[i].produktNavn + '</option>';  
            }  
            $("#bilType").html(s);  
        }  
    });  
});