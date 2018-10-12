$(document).ready(function () {
    var baseUrl = "http://localhost:50812/items"

    function xhrFail(xhr, status, err) {
        console.log(xhr, status, err);
        $("#messages").text(xhr.responseJSON.message);
    }

    $("#addMoney button").click(function () {
        var money = parseFloat($("#displayMoney").val());
        if (this.innerText.toUpperCase() == "ADD DOLLAR") {
            $("#displayMoney").val((money += 1).toFixed(2));
        }
        if (this.innerText.toUpperCase() == "ADD QUARTER") {
            $("#displayMoney").val((money += .25).toFixed(2));
        }
        if (this.innerText.toUpperCase() == "ADD DIME") {
            $("#displayMoney").val((money += .10).toFixed(2));
        }
        if (this.innerText.toUpperCase() == "ADD NICKEL") {
            $("#displayMoney").val((money += .05).toFixed(2));
        }
    });

    $("#returnChange").click(function () {
        var totalPennies = parseFloat($("#displayMoney").val()) * 100;
        var quarters, dimes, nickels, pennies;
        quarters = Math.floor(totalPennies / 25);
        totalPennies = totalPennies % 25;
        dimes = Math.floor(totalPennies / 10);
        totalPennies = totalPennies % 10;
        nickels = Math.floor(totalPennies / 5);
        totalPennies = totalPennies % 5;
        pennies = Math.floor(totalPennies / 1);

        $("#displayMoney").val(0)
        $("#messages").text("");
        $("#itemNumber").val("");
        displayChange(quarters, dimes, nickels, pennies);
    });

    function displayChange(quarters, dimes, nickels, pennies) {
        $("#changeText").text("")
        if (quarters > 0) {
            $("#changeText").text("Quarters: " + quarters);
        }
        if (dimes > 0) {
            $("#changeText").text($("#changeText").val() + "\n" + "Dimes: " + dimes);
        }
        if (nickels > 0) {
            $("#changeText").text($("#changeText").val() + "\n" + "Nickels: " + nickels);
        }
        if (pennies > 0) {
            $("#changeText").text($("#changeText").val() + "\n" + "Pennies: " + pennies);
        }
    };

    $("#makePurchase").on("click", function () {
        var snacks = $(".snack");
        var itemNumber = $("#itemNumber").val();
        for (var i = 0; i < snacks.length; i++) {
            if (snacks[i].firstChild.firstChild.nextSibling.firstChild.innerText == itemNumber) {
                var money = $("#displayMoney").val();
                var buyUrl = "http://localhost:50812/money/" + money + "/item/" + snacks[i].firstChild.firstChild.value;

                $.getJSON(buyUrl)
                    .done(function (response) {

                        displayChange(response.quarters, response.dimes, response.nickels, response.pennies);
                        $("#displayMoney").val(0)
                        $("#messages").text("Thank You!!!");
                        loadSnacks();
                    })
                    .fail(xhrFail);
            }

        }
    });





    function loadSnacks() {
        $("#snacks").empty();

        $.getJSON(baseUrl)
            .done(function (response) {
                var snacks = $("#snacks")
                var numberCount = 1;

                response.forEach(function (snack) {
                    snacks.append('<div class="col-4 card snack block" onclick="showSnackNumber(this)">'
                        + '<div class="card-body">'
                        + '<input type="hidden" value=' + snack.id + ' />'
                        + "<div><label>" + numberCount + "</label></div>"
                        + "<div><label>" + snack.name + "</label></div>"
                        + "<div><label>$" + snack.price + "</label></div>"
                        + "<div><label>Quantity Left: " + snack.quantity + "</label></div>"
                        + '</div>'
                        + '</div>');
                    numberCount++;
                });

            })
            .fail(xhrFail);
    };







    loadSnacks();
});

function showSnackNumber(snack) {
    $("#itemNumber").val(snack.firstChild.firstChild.nextSibling.firstChild.innerText);
    // var snacks = $(".snack")
    // alert(snacks[0].firstChild.firstChild.value);
};

$(".snacks").hover(function(){
    $(this).addClass("shadow-lg p-3 mb-5 bg-white rounded");
},
function(){
    $(this).removeClass("shadow-lg p-3 mb-5 bg-white rounded");
});

