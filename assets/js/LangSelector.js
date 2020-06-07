function ChangeActive(val) {
    val = val.toUpperCase();
    var liS = document.getElementsByClassName("liLang");
    for (var i = 0; i < liS.length; i++) {
        if (liS[i].innerText.toUpperCase() == val) {
            $(liS[i]).addClass("active");
        } else {
            $(liS[i]).removeClass("active");
        }
    }
}

function ChangeLangCookie(val) {
    $("#preloader").fadeIn("fast");
    setCookie("Lang", val, 365);
    LangReq("Index");
}


function CheckForLanguageCookie() {
    if (getCookie("Lang") == "") {
        setCookie("Lang", 'En', 365);
    }
    var cookieVal = getCookie("Lang");
    ChangeActive(cookieVal);
    return cookieVal;
}


var _data;
function LangReq(PageName) {

    if (_data == null) {
        $.ajax('/Resources/' + PageName + 'Lang.json',
            {
                contentType: "application/json; charset=utf-8",
                timeout: 5000,     // timeout milliseconds
                headers: {
                    'content-type': 'application/json; charset=utf-8"',
                    'content-encoding': 'ISO-8859-1'
                },
                success: function (data) {   // success callback function
                    _data = data;
                    SetLanguage(_data);
                },
                error: function (errorMessage) { // error callback 
                    console.log("Dil Seçilirken Hata Oluştu ! errMsg => " + errorMessage);
                }
            });
    } else {
        SetLanguage(_data);
    }
}

function SetLanguage(LangSet) {

    var selectedLang = CheckForLanguageCookie();

    var elems = document.body.getElementsByTagName("*");
    for (var j = 0; j < elems.length; j++) {

        for (var i = 0; i < LangSet.properties.length; i++) {
            if (LangSet.properties[i]['id'] == elems[j].getAttribute("id")) {
                //console.log("Element id => " + elems[j].getAttribute("id"));
                //console.log("LangSet.Property.id => " + LangSet.properties[i]['id']);
                //console.log("Selected Lang Value => " + LangSet.properties[i][selectedLang]);
                elems[j].innerText = LangSet.properties[i][selectedLang];
            }
        }
    }

    $("#preloader").fadeOut("slow", "swing");
}

$(window).on('load', function () {
    $("#preloader").fadeOut("slow", "swing");
});