var roleJs = {
    post: function (url, data) {
        $.ajax({
            type: "POST",
            url: url,
            data: { model: data },
            datatype: String,
            success: function (response) {
                alert(response.result);
                window.location = response.url;
            },
            error: function (error) {
                alert('User already is in role');
            }
        })
    },
    InsertOrDeleteUserInRole: function (e) {
        console.log(e);
        var userId = e.id.substr(0, 36);
        var roleName = e.id.substr(36);
        var roleAndUser = {
            userId: userId,
            roleName: roleName
        };
        roleJs.post('createRole', roleAndUser);
    }
}
