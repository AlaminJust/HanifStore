var Order = {
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
                alert('Add to cart failed.');
            }
        })
    },
    insertShoppingCartItem: function (productId) {
        console.log(productId);
        var data = {
            ProductId : productId,
            AttributeXml : "Etc",
            Subtotal : 100,
            Quantity : 1
        };
        roleJs.post('order/addtocart', data);
    }
}