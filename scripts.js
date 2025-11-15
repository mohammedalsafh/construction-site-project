//this is a function that handles all the email validation in multiple pages
function validateEmail(email) {

  // the email must have @ and can end or start with @ 
  if (!email.includes("@") || email.startsWith("@") || email.endsWith("@")) {
    alert("Email must contain a valid @ symbol");
    return false;
  }

  // we reject if the user enter somthing like r@.com meaning there has to be somthing after the @ and before the .com
  var atIndex = email.indexOf("@");
  if (email.charAt(atIndex + 1) === ".") {
    alert("Email cannot have '.' immediately after '@'");
    return false;
  }

  // the email must have .somthing 
  var domainPart = email.split("@")[1];
  if (!domainPart.includes(".")) {
    alert("Email must contain a domain like .com or .sa");
    return false;
  }

  return true;
}

//this is a function that handles all the passwords validation in multiple pages
function validatePassword(pass) {

  // passowrd cant be less that 8 characters
  if (pass.length < 8) {
    alert("Password must be at least 8 characters long");
    return false;
  }

  //the password need atleast 1 num
  var numberPattern = /[0-9]/;
  if (!numberPattern.test(pass)) {
    alert("Password must contain at least one number");
    return false;
  }

  return true;
}

var grandTotal = 0;

function addToCart(productId, productName, productPrice, productImageSrc) {
  //used to create unique row ids for each product added to the cart
  var rowId = 'cart-row-' + productId;
  var existingRow = document.getElementById(rowId);
  var cartBody = document.getElementById('cart-body');
  var cartFoot = document.getElementById('cart-foot');
  var newTotal = 0;
  if (existingRow) {
    var quantity = document.getElementById('quantity-' + productId);
    var newQuantity = parseInt(quantity.value) + 1;
    quantity.value = newQuantity;
    quantity.value = newQuantity;
  }
  else if (!existingRow) {

    var newRow = '<tr id="' + rowId + '">';

    newRow += '<td><img src="' + productImageSrc + '" alt="' + productName + '" width="50"></td>';
    newRow += '<td>' + productName + '</td>';
    newRow += '<td><input type="number" id="quantity-' + productId + '" value="1" min="1" max="50"></td>';
    newRow += '<td>' + productPrice.toFixed(2) + ' SR</td>';
    newRow += '</tr>';
    cartBody.innerHTML += newRow;




  }

  grandTotal += parseFloat(productPrice);
  var total = document.getElementById('total-cell');
  total.innerHTML = grandTotal.toFixed(2) + ' SR';

  showPage('cart-section');

  checkCart();

}

function showPage(pageId) {
  var storePage = document.getElementById('store-section');
  var cartPage = document.getElementById('cart-section');

  storePage.style.display = 'none';
  cartPage.style.display = 'none';

  var pageToShow = document.getElementById(pageId);
  pageToShow.style.display = 'block';

  if (pageId === 'store-section') {
    filterProducts('all');
  }
}

function filterProducts(category) {


  var allProducts = document.getElementsByClassName('product-item');

  for (var i = 0; i < allProducts.length; i++) {
    var product = allProducts[i];


    if (category === 'all' || product.classList.contains(category)) {
      product.style.display = 'block';
    } else {
      product.style.display = 'none';
    }
  }
}


function changeProductImage(imageId, newSrc) {


  var imageElement = document.getElementById(imageId);


  imageElement.src = newSrc;
}


// if more than 1 row means at least 1 product
function checkCart() {
  var table = document.getElementById("cart-table");
  var rows = table.rows.length;

  if (rows > 1) {
    document.getElementById("payment-button-container").innerHTML =
      "<a href='payment.html'><button class='payment-btn-nav'>Proceed to Payment</button></a>";
  }
}

