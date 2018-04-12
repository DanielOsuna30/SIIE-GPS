$(function () {
    $('#editStudent').click(function () {
        var data = {
            LastNameP: $('#LastNameP').val(),
            LastNameM: $('#LastNameM').val(),
            Name: $('#Name').val(),
            Gender: $('#Gender').val(),
            CareerOption1: $('#CareerOption1').val(),
            Address: $('#Address').val(),
            State: $('#State').val(),
            Municipality: $('#Municipality').val(),
            Nationality: "Mexicano",
            PostalCode: $('#PostalCode').val(),
            Suburb: $('#Suburb').val(),
            PhoneNumber: $('#PhoneNumber').val(),
            Email: $('#Email').val(),
            CivilStatus: $('#CivilStatus').val(),
            Password: $('#Password').val()
        }
        $.ajax({
            url: '/Admin/Alumnos/'+$('#noControl').val()+'/Edit',
            method: 'PATCH',
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    alert('Cambios guardados');
                    window.location.href = "/Admin";
                }
                else
                    alert("Error, verifique que los campos estan correctos");
            }
        });
    })
});
$(function () {
    $('#editTeacher').click(function () {
        var data = {
            Nombre: $('#Nombre').val(),
            ApellidoP: $('#ApellidoP').val(),
            ApellidoM: $('#ApellidoM').val(),
            Direccion: $('#Direccion').val(),
            Estado: $('#Estado').val(),
            Municipio: $('#Municipio').val(),
            Colonia: $('#Colonia').val(),
            CP: $('#CP').val(),
            Telefono: $('#Telefono').val(),
            Correo: $('#Correo').val(),
            Password: $('#Password').val(),
        }
        $.ajax({
            url: '/Admin/Maestros/' + $('#NumEconomico').val() + '/Edit',
            method: 'PATCH',
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    alert('Cambios guardados');
                    window.location.href = "/Admin/Maestros/";
                }
                else
                    alert("Error, verifique que los campos estan correctos");
            }
        });
    })
});
$(function () {
    $('#editMateria').click(function () {
        var data = {
            NombreMateria: $('#NombreMateria').val(),
            AbreviacionMateria: $('#AbreviacionMateria').val(),
            Clave: $('#Clave').val(),
            Creditos: $('#Creditos').val(),
            HrsTeoricas: $('#HrsTeoricas').val(),
            HrsPracticas: $('#HrsPracticas').val(),
            PlanEstudios: $('#PlanEstudios').val(),
        }
        $.ajax({
            url: '/Admin/Materias/' + $('#idMateria').val() + '/Edit',
            method: 'PATCH',
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    alert('Cambios guardados');
                    window.location.href = "/Admin/Materias/";
                }
                else
                    alert("Error, verifique que los campos estan correctos");
            }
        });
    })
});

$(function () {
    $('#createUser').click(function () {
        var data = {
            LastNameP: $('#LastNameP').val(),
            LastNameM: $('#LastNameM').val(),
            Name: $('#Name').val(),
            Gender: $('#Gender').val(),
            CareerOption1: $('#CareerOption1').val(),
            Address: $('#Address').val(),
            State: $('#State').val(),
            Municipality: $('#Municipality').val(),
            Nationality: "Mexicano",
            PostalCode: $('#PostalCode').val(),
            Suburb: $('#Suburb').val(),
            PhoneNumber: $('#PhoneNumber').val(),
            Email: $('#Email').val(),
            CivilStatus: $('#CivilStatus').val(),
            Password: $('#Password').val(),
            Level:$('#Level').val(),
            CareerOption1:$('#CarrerOption1').val(),
        }
        $.ajax({
            url: '/Admin/Create/',
            method: 'POST',
            data: data,
            success: function (response) {
                if (response.status == 200) {
                    alert('Usuario guardados');
                    if(data.Level=="3")
                    window.location.href = "/Admin/";
                    else
                    window.location.href = "/Admin/Maestros";

                }
                else
                    alert("Error, verifique que los campos estan correctos");
            }
        });
    })
});
$(function () {$('#Level').on('change', function() {
    if($('#Level').val()=="3")
    {
        $('#CarrerOptionLabel').css('visibility','visible');
        $('#CarrerOption1').css('visibility','visible');
    }
    else
    {
    $('#CarrerOptionLabel').css('visibility','hidden');
    $('#CarrerOption1').css('visibility','hidden');
 }
}
);
});