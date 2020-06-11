//$(document).ready(function () {
//    $('#checkbox').prop('checked', true);
//    $('#textInput').prop('disabled', true);

//    // Enable-Disable text input when checkbox is checked or unchecked

//    $('#checkbox').change(function () {
//$('.checkbox').prop($(this).is(':checked'));
//    });
//});

$(document).on("change", ".checkbox", function () {
    var id = this.id
    //var values = $("input[this]:checked")
    var active = false;
    if (this.checked) {
        active = true;
    }
    getExpenseDetailsByExpenseId(id, active)
});

function getExpenseDetailsByExpenseId(id, active) {
    //var Vm = {
    //    "Id": id,
    //};
    var Vm= id
    $.ajax({
        type: "POST",
        url: '/../../MenuCreate/CheckActivity',
        data: Vm,
        success: function (data) {
            if (data) {
                $('.checkbox').prop('disabled', $(this).is(':checked'));
                alert("Success!");

            }
            else {
                alert("Some thing went wrong!");
            }

        }
    });
}