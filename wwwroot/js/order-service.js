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
        this.post('order/addtocart', data);
    },
    updateShoppingCartItem: function (Id,selector1,selector2) {
        const isSelected = $(selector1).is(':checked'),
            quantity = parseInt($(selector2).val());
        const data = {
            Id: Id,
            Quantity: quantity,
            isSelected: isSelected
        };
        this.post('update', data);
    },
    deleteShoppingCartItem: function (Id) {
        console.log(Id);
        var data = {
            Id: Id
        };
        this.post('remove',data);
    },
    cartItemPlusMinus: function (plusMinus , selector) {
        var element = $(selector);
        var value = parseInt(element.val());
        if (plusMinus == '+') {
            element.val(value + 1);
        }
        else {
            if (value == 0) value = 1;
            element.val(value - 1);
        }
    }

}