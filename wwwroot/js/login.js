
var user = {
    post: function (url, data) {
        $.ajax({
            type: "POST",
            url: url,
            data: { model: data },
            datatype: String,
            success: function (response) {
                if (response.result == 'Redirect')
                    window.location = response.url;
            },
            error: function (error) {
                alert(error.responseJSON.value.result);
            }
        })
    },
    login: function () {
        var username = document.getElementById("username");
        var password = document.getElementById("password");
        var Login = {
            UserName: username.value,
            Password: password.value,
            RemeberMe: true
        };
        user.post("Users/Login", Login);
    }
}