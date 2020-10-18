var categoryJs = {
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
                alert(error.responseJSON.value.error);
            }
        })
    },
    createCategory: function () {
        var categoryName = document.getElementById("category-name");
        var category = {
            CategoryName: categoryName.value,
            CreatedOn: new Date(),
            IsPublish: true,
            DisplayOrder: 1
        };
        categoryJs.post("category", category);
    }
}
