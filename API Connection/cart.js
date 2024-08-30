
if (cartTable) {
    const allCartAPI = "https://localhost:44353/api/CartItem/GetAllCartItems";
    async function loadCart() {
        const cartData = await fetch(allCartAPI);
        var cartJson = await cartData.json();

        const tableBody = document.getElementById("cartTableBody");
        const cartID = localStorage.getItem("CartID");

        function fillCart() {
            cartJson.forEach((element) => {
                if (element.cartId == cartID) {
                    tableBody.innerHTML +=
                        `
                            <tr>
                                <td>${element.prodcutDTO.productName}</td>
                                <td><img src="../images/${element.prodcutDTO.productImage}" alt="" style="width:10em"></td>
                                <td>${element.prodcutDTO.price}</td>
                                <td><input id="QuantityNumber-${element.cartItemId}" type="number" value="${element.quantity}"></td>
                                <td><Button onclick="UpdateQuantity(${element.cartItemId})">Edit</Button></td>
                                 <td><Button onclick="DeleteItem(${element.cartItemId})">Delete</Button></td>
                            </tr>
                        `;
                }
            });
        }
        fillCart();
    }
    loadCart();
}

function UpdateQuantity(cartItemId) {
    const cartAPI = `https://localhost:44353/api/CartItem/UpdateCartById/${cartItemId}`;
    const quantityInput = document.getElementById(`QuantityNumber-${cartItemId}`);
    const newQuantity = quantityInput.value;
    
    fetch(cartAPI, { 
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            quantity: newQuantity
        })

    })

    alert("Updated");

}


function DeleteItem (CartItem) {
    const cartAPI = `https://localhost:44353/api/CartItem/DeleteCartItemByID/${CartItem}`;
    fetch(cartAPI, { 
        method: "DELETE"
        })


    alert("Deleted");

}