$(document).ready(function () {
    console.log('Modulo: Administración Usuarios');
    tblinitialize();
    ddlinitialize();
});

function tblinitialize() {
    var tbl = $('#tbl-user').DataTable({
        ajax: { url: 'User/ConsultaUsuario', dataSrc: '' },
        paging: true,
        lengthChange: false,
        ordering: true,
        info: true,
        autoWidth: false,
        //pageLength: 5,
        language:
        {
            paginate: { previous: 'Anterior', next: 'Siguiente' },
            info: 'Pagina _PAGE_ de _PAGES_', infoEmpty: '', infoFiltered: '',
            search: 'Buscar: ', zeroRecords: 'No existen coincidencias'
        },
        columns: [{ data: 'tuid' }, { data: 'uname' }, { data: 'email' },
        { data: 'tgdescription' }, { data: 'sdescription' }],
        columnDefs: [
            {
                targets: 5,
                className: 'text-center redit',
                render: function (data, type, row, meta) {
                    return '<a><i data-toggle="modal" data-target="#mform_user" class="fa fa-user-edit" style="color:green; font-size: 24px; text-align: center;"></i></a>';
                }
            },
            {
                targets: 6,
                className: 'text-center',
                render: function (data, type, row, meta) {
                    var str = '';
                    if (row.ustatus) {
                        str = '<a class="rdelete"><i class="fa fa-user-minus" style="color:red; font-size: 24px; text-align: center;"></i></a>';
                    }

                    return str;
                }
            }],
    });

    tbl.on('click', 'td.redit', function (e) {
        var ddl = $('#tgid');
        var row = tbl.row(this).data();

        $('#tuid').val(row.tuid);
        $('#email').val(row.email);
        $('#uname').val(row.uname);
        $('#upwd').val(row.upwd);

        ddl.val(row.tgid);
        ddl.prop('disabled', true);
        ddl.selectpicker('refresh');
    }).on('click', 'a.rdelete', function (e) {
        var tr = $(this).parents('tr');
        var row = tbl.row(tr).data();
        deleteitem(row.tuid);
    });
}

function deleteitem(tuid) {
    $.ajax({
        url: 'User/EliminaUsuario',
        type: 'post',
        data: { tuid: tuid },
        success: function (response) { resetForm(); },
        error: ajax_error
    });
}

function ddlinitialize() {
    $.ajax({
        url: 'User/ConsultaGenero',
        type: 'post',
        success: ddlsuccess,
        complete: function () { $('.umultiselect').selectpicker({ title: 'Seleccione...', size: 8 }); },
        error: ajax_error
    });
}

function ddlsuccess(response) {
    if (response) {
        $.each(response, function (index, item) {
            var option = new Option(item.tgdescription, item.tgid);
            $('#tgid').append(option);
        });
    }
}

$('#frm-user').on('submit', function (e) {
    e.preventDefault();

    var data = $(this).serialize();
    $.ajax({
        url: 'User/GuardaUsuario',
        type: 'post',
        data: data,
        success: function (response) { $('#mform_user').modal('toggle'); },
        error: ajax_error
    });
});

$('#mform_user').on('hidden.bs.modal', function () {
    resetForm();
});

function resetForm() {
    var ddl = $('#tgid');
    var tbl = $('#tbl-user');

    reload_table(tbl, false);
    
    ddl.val('');
    ddl.prop('disabled', false);
    ddl.selectpicker('refresh');

    $('#frm-user :input').not(':button, :submit, [name=__RequestVerificationToken]').val('');
}

function reload_table(ctrl, reset) {
    var tbl = ctrl.DataTable();
    if (tbl) {
        tbl.ajax.reload(null, reset);
    }
}

function ajax_error(XMLHttpRequest, textStatus, errorThrown) {
    console.log('Error: ', XMLHttpRequest.status, XMLHttpRequest.statusText);
    console.log('Response Error:', XMLHttpRequest.responseText);
}