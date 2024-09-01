

let form = document.getElementById("registerForm");
form.addEventListener('submit', async function (e) {
    e.preventDefault(); 

    
  
    let formData = new FormData(); // Create a new FormData object
    formData.append("username", document.getElementById("username").value);
    formData.append("email", document.getElementById("Email").value);
    formData.append("password", document.getElementById("Password").value);

  
    
    let response = await fetch("https://localhost:44353/api/Users/registerNew", {
        method: "POST",
        body: formData
    });
  
    if (response.ok) {
        Swal.fire({
            icon: 'success',
            title: 'User added successfully!',
            showConfirmButton: true,
            timer: 1500
        });
       
        // window.location.href = "index.html";
    } else {
        Swal.fire({
            icon: 'error',
            title: 'Failed to add user',
            text: 'Please try again.',
            timer: 2000
        });
    }
});



// async function RegisterNewUser() {
// let url = "https://localhost:44353/api/Users/registerNew";

// let request = await fetch (url, {
//     method: 'POST', 
//     headers: {
//                 'Content-Type': 'multipart/form-data'
//             },
//     body: JSON.stringify({
//         username: document.getElementById("username").value,
//         email: document.getElementById("Email").value,
//         password: document.getElementById("Password").value,
       
//     })

    
// })

// if (response.ok) {
//     alert("Registration successful!");
// } else {
//     alert("Registration failed. Please check your inputs.");
// }}








// let url = "https://localhost:44353/api/Account/Register";
// let request = await fetch(url, {
//     method: 'POST',
//     headers: {
//         'Content-Type': 'application/json'
//     },
//     body: JSON.stringify({
//         Email: document.getElementById("Email").value,
//         Password: document.getElementById("Password").value,
//         ConfirmPassword: document.getElementById("ConfirmPassword").value
//     })
// });