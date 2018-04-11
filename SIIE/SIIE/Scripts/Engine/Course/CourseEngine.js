$(document).ready(function () {
    $('#InscriptionSumbit').click(function () {
        var data = {
            LastNameP: $('#LastNameP').val(),
            LastNameM: $('#LastNameM').val(),
            Name: $('#Name').val(),
            Gender: $('#Gender').val(),
            CareerOption1: $('#CareerOption1').val(),
            Address: $('#Address').val(),
            State: $('#State').val(),
            Municipality: $('#Municipality').val(),
            Nationality:"Mexicano",
            PostalCode: $('#PostalCode').val(),
            Suburb: $('#Suburb').val(),
            PhoneNumber: $('#PhoneNumber').val(),
            Email: $('#Email').val(),
            CivilStatus: $('#CivilStatus').val(),
            Password: $('#Password').val()
        }
        $.ajax({
            url: '/Inscripcion',
            method: 'POST',
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    alert("Su numero de control:" + response.controlNumber);
                    window.location.href = "/";
                }
                else
                    alert("Error, intentelo mas tarde")
            }
        });
    }
    )
});