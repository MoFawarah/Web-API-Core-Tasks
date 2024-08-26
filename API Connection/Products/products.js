


let n = localStorage.getItem("categoryID");


async function getProducts () {
debugger
if (n !== null) {
var url = `https://localhost:44353/api/Products/GetProductsByCatID/${n}`;

}
else {
var url = "https://localhost:44353/api/Products/GetAllProducts";
}

let request = await fetch(url);

let data = await request.json();

let card = document.getElementById("container");

data.forEach(product => {
    card.innerHTML += `
    <div class="col-md-4">
        <div class="card mb-4 shadow-sm">
            <img class="card-img-top" src="${product.productImage}" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title">${product.productName}</h5>
                <p class="card-text">${product.description}</p>
                <div class="d-flex justify-content-between align-items-center">
                    <div class="btn-group">
                        <button onclick="SaveProductID(${product.productId})" type="button" class="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" class="btn btn-sm btn-outline-secondary">Add to Cart</button>
                    </div>
                    <small class="text-muted">${product.price}$</small>
                </div>
            </div
`
});


}

getProducts();


function SaveProductID(id) {
    localStorage.setItem("productId", id);
    window.location.href = "../ProductDetails/productdetails.html";
}

a