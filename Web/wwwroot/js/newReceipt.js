let quantityInput = document.getElementById("quantity-input");
let remainingStock = document.getElementById("remaining-stock");
let itemTotalPrice = document.getElementById("Item-total-price");
let totalPrice = document.getElementById("total-price");
let stockAmount = document.getElementById("stockAmount");

quantityInput.addEventListener('input', function (e) {
    console.log(quantityInput.value);
    console.log(stockAmount.innerText);
});
