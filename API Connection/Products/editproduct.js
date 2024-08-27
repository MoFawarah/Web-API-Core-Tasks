
let productId = localStorage.getItem("productId");

let form = document.getElementById("productForm");
form.addEventListener('submit', async function (e) {
    e.preventDefault(); 
  
    let formData = new FormData(); // Create a new FormData object
    formData.append("ProductName", document.getElementById("ProductName").value);
    formData.append("Description", document.getElementById("Description").value)
    formData.append("Price", document.getElementById("Price").value)
    formData.append("CategoryId", document.getElementById("CategoryId").value)
    
    formData.append("ProductImage", document.getElementById("ProductImage").files[0]);
  
    
    let response = await fetch(`https://localhost:44353/api/Products/UpdatedProduct/${productId}`, {
        method: "Put",
        body: formData
    });
    alert("Product Updated Successfully!")
  
    // if (response.ok) {
    //     alert("Category added successfully!");
    //     // window.location.href = "index.html";
    // } else {
    //     alert("Failed to add category. Please try again.");
    // }
  });