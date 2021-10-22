// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function verialma() {
    var kulAyırma = document.getElementById("kulAyırma").value;
    if (kulAyırma == "user") {

        var identity = document.getElementById("identity").value;
        var password = document.getElementById("sifre").value;

        $.ajax({
            url: "../Kullanıcı/kullanıcıKontrol",
            type: "GET",
            data: { identity: identity, password: password },
            dataType: "Json",
            success: function (result) {
                alert(result);
                if (result == "Giriş Başarılı") {
                    window.location.href = "./Home/KullanıcıAnasayfa";
                }
            }
        });
    }

    else {

        var username = document.getElementById("username").value;
        var password = document.getElementById("sifre").value;
        alert(username);
        $.ajax({
            url: "../Admin/kullanıcıKontrol",
            type: "GET",
            data: { username: username, password: password },
            dataType: "Json",
            success: function (result) {
                alert(result);
                if (result == "Giriş Başarılı") {
                    window.location.href = "./AdminAnasayfa";
                }
            }
        });


    }
}