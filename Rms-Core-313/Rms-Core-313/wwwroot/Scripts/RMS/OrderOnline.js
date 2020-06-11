$(document).ready(function () {
    //$('.toggle').bootstrapToggle({
    //    on: 'Y',
    //    off: 'N',
    //    width: '10px',
    //    size: 'small'
    //});
    AllMenus();

    if ($("#viewbaddata").val()== "true") {
        
        $("#errorMsg").fadeTo(3000, 500).slideUp(500);
    }
    else {
        $("#errorMsg").hide();
    }
    
   
});

function AllMenus() {
    $.ajax({
        type: "GET",
        url: "/../../MenuCreate/GetTypes",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== undefined && data !== null && data !== "") {
                var ul = $("#ul");
                var Menulist = $("#mainlist");
                data.forEach((i) => {

                    var sectionList = "<li role='presentation'><a id='" + i.id + "' aria-controls='home' class='Typebtn'  role='tab' data-toggle='tab'>" + i.name + "</a></li>"
                    var div = '<div role="tabpanel" class="tab-pane fade in active" id="' + i.id + '"></div>';

                    ul.append(sectionList);
                    Menulist.append(div);

                });

            }
        }
    });
    $.ajax({
        type: "GET",
        url: "/../../MenuCreate/GetAllMenuList",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== undefined && data !== null && data !== "") {
                var tagId = String("#tabpanelData");
                var dropdown = $(tagId);
                dropdown.append(data);

            }
        }
    });

}
function allData() {
    $.ajax({
        type: "GET",
        url: "/../../MenuCreate/GetAllMenuList",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== undefined && data !== null && data !== "") {
                var tagId = String("#tabpanelData");
                var dropdown = $(tagId);
                dropdown.html("");
                dropdown.append(data);

            }
        }
    });
}

function MenudataById(id) {
    $.ajax({
        type: "GET",
        url: "/../../MenuCreate/GetMenuListByType?id="+id,
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== undefined && data !== null && data !== "") {
                var tagId = String(".tabpanelData");
                var dropdown = $(tagId);
                dropdown.html("");
                dropdown.append(data);

            }
        }
    });
}

$(document.body).on("click", ".Typebtn", function (event) {
    //var btn = $(this);
    var id = this.id;
    MenudataById(id)
});
$(document.body).on("click", ".AllData", function (event) {
    //var btn = $(this);
    allData();
});
var DataArray = [];
$(document.body).on("click", ".submit", function (event) {
    var btn = $(this);
    var id = this.id;
    var price = btn.attr("data-Price");
    var name = btn.attr("data-Name");

    var data =
    {
        Name: name,
        Price: price,
        Id: id,
        Quantity: 1
    }
    GetAllTerminal(data);
});
var IsPush = false;
function GetAllTerminal(data) {

    if (DataArray.length != 0) {
        for (i = 0; i < DataArray.length; i++) {

            if (DataArray[i].Id == data.Id) {
                DataArray[i].Quantity += 1;
                DataArray[i].Price = (DataArray[i].Quantity * data.Price)
                addToCart(DataArray);
                return;
            }

        }
        DataArray.push(data);
        addToCart(DataArray);

    }
    else {
        DataArray.push(data);
        addToCart(DataArray);
    }

}
var contain = "";

function addToCart(DataArray) {
    $("#HiddenField").html("");

    //var totalAmount = 0;
    //var totalQuantity = 0;
    //for (i = 0; i < DataArray.length; i++) {

    //    addRowForOrderDetails(DataArray[i], i)
    //    contain += '<tr><th scope="row">' + DataArray[i].Quantity + '</th><td>' + DataArray[i].Name + '</td><td> ₤' + DataArray[i].Price + '</td><td><p Class="Delete" id="' + DataArray[i].Id + '"><span class="glyphicon glyphicon-trash"></span></p></td></tr>'
    //    totalAmount += Number(DataArray[i].Price);
    //    totalQuantity += Number(DataArray[i].Quantity);

    //}
   
    var phone = '<br /> <table class="table"><tr><td><h4> Reciver Phone: </h4></th><td><input id="phone" class= "col-xs-3 form-control input-sm" type = "text" name="ReciverPhone" id = "ReciverPhone" placeholder = "Phone No"/></td></tr></table>'
    var button = '<label class="col-12" style="margin-left:20px; ">Cash On Delivery</label><input style = "margin-left:20px; " id = "chkToggle1" type = "checkbox" data-toggle="toggle">'
    var TagTotal = '<div>' + phone + '<h5 style="color:grey"> Please Enter your phone number before plece your order </h5><br /> <br /> <h5>Total Amount : ₤' + totalAmount + '</h5> <h5> Total Quantity :' + totalQuantity + ' </h5> <h5> Discount : 0% </h5> <hr /></div> <label class="col-12" style="margin-left:20px; ">Cash On Delivery</label><input style = "margin-left:20px;" name="IsCashOnDelivery" type = "checkbox"><button type="submit" id="submit" class="btn btn-primary btn-lg btn-block">Place Your Order</button>'


    ////contain += TagTotal;
    //$("#placeOrder").html("");
    //$("#footer").html("");
    //$("#placeOrder").append(contain);
    $("#footer").append(TagTotal);
    contain = "";
}
$(document.body).on("click", ".Delete", function (event) {
    var btn = $(this);
    var id = this.id;
    for (i = 0; i < DataArray.length; i++) {

        if (DataArray[i].Id == id) {
            DataArray.slice(0, i);
            DataArray = DataArray.filter(item => item !== DataArray[i]);
            addToCart(DataArray);
            return;
        }

    }
});




function addRowForOrderDetails(DataArray, i) {

    var MenuItemCell = "<td><input type='hidden'  name='OrderPlaceDetails[" + i + "].MenusCreateId' value='" + DataArray.Id + "' />";
    var QuantityCell = "<td><input type='hidden'  name='OrderPlaceDetails[" + i + "].Quantity' value='" + DataArray.Quantity + "' />";
    var PriceCell = "<td><input type='hidden'  name='OrderPlaceDetails[" + i + "].Price' value='" + DataArray.Price + "' />";

    var newRow = MenuItemCell + QuantityCell + PriceCell;

    $("#HiddenField").append(newRow);

}
$(document.body).on("click", ".Confirm", function (event) {
    
    var id = this.id;
     $.ajax({
         type: "GET",
         url: '"/../../SendingMail/mailBody?id=' + id + '',
         contentType: "application/json; charset=utf-8",
         success: function (data) {
             if (data !== null) {
                 var vm = {
                     "id": id,
                     "mailBody":data
                 }
                 $.ajax({
                     type: "POST",
                     url: '/../../SendingMail/Index',
                     data: vm,
                     success: function (ndata) {
                         if (ndata !== null) {
                             location.reload();

                         }

                     }
                 });
                
                
             }
         }
     });
});
$(document.body).on("click", ".Reject", function (event) {
    
    var id = this.id;
    $.ajax({
        type: "GET",
        url: '"/../../SendingMail/Reject?id=' + id + '',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== false) {

                location.reload();
            }
        }
    });
});
$(document.body).on("click", ".Kitchen", function (event) {

    var id = $(this).attr("data-orderID");
    $.ajax({
        type: "GET",
        url: '"/../../SendingMail/mailBodyKitchen?id=' + id + '',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            var vm = {
                "id": id,
                "mailBody": data
            }
            $.ajax({
                type: "POST",
                url: '/../../SendingMail/Kitchin',
                data: vm,
                success: function (ndata) {
                    if (ndata !== null) {
                        location.reload();

                    }

                }
            });

        }
    });
}); 

$(document.body).on("click", ".Delivering", function () {

    
    var OrderId = $(this).attr("data-orderID");

    $.ajax({
        type: "GET",
        url: "/../../SendingMail/Delivering?OrderId=" + OrderId + "",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data !== false) {
                location.reload();

            }
        }
    });
});