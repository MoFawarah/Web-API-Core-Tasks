

let n = Number(localStorage.getItem("productId"));
async function ShowProductDetails() {
    let url = `https://localhost:44353/api/Products/GetOneProduct/${n}`
    let request = await fetch(url);

    let product = await request.json();
     

    let card = document.getElementById("container");
    card.innerHTML = `
        <div class="row"> 
        <div class="card" style="width: 18rem;">
            <img class="card-img-top" src="${product.productImage}" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title">${product.productName}</h5>
                <p class="card-text">${product.description}</p>
                <p class="card-text"><strong>Price:</strong> ${product.price}$</p>
                <a href="#" onclick="saveCategoryID(${product.price})" class="btn btn-primary">Save ID</a>
                <a href="#" onclick="gotoedit()" class="btn btn-primary">edit product</a>
            </div>
        </div>
        </div>
    `;
}

ShowProductDetails();
function gotoedit() {
window.location.href = "../Products/editProduct.html";
}
