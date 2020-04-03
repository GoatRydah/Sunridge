//var editor;

//$(document).ready(function () {
//    LoadList();
//});

//function LoadList() {
//    editor = new $.fn.dataTable.Editor({
//        ajax: "/api/ownerIndex/",
//        table: "#DT_Load",
//        fileds: [{
//            label: "First Name:",
//            name: "ApplicationUser.FirstName"
//        }, {
//            label: "Last Name:",
//            name: "ApplicationUser.LastName"
//        }, {
//            label: "Username:",
//            name: "ApplicationUser.UserName"
//        }, {
//            label: "Emergency Contact Name:",
//            name: "ApplicationUser.EmergencyContactName"
//        }, {
//            label: "Emergency Contact Phone:",
//            name: "ApplicationUser.EmergencyContactPhone"
//        }, {
//            label: "Emergency Contact Phone:",
//            name: "ApplicationUser.EmergencyContactPhone"
//        }, {
//            label: "Lot Number:",
//            name: "Lot.LotNumber"
//        }
//        ]
//    });


//    $('#DT_Load').DataTable({

//        ajax: "/api/ownerIndex/",
//        dom: 'Bfrtip',
//        columns: [
//            { data: "ApplicationUser.FirstName", width: "11%" },
//            { data: "ApplicationUser.LastName", width: "11%" },
//            { data: "ApplicationUser.UserName", width: "11%" },
//            { data: "ApplicationUser.EmergencyContactName", width: "11%" },
//            { data: "ApplicationUser.EmergencyContactPhone", width: "11%" },
//            { data: "Lot.LotNumber", width: "11%" },
//            {
//                data: "id",
//                render: function (data) {
//                    return ` <div class="text-center">
//                                <a href="/admin/owners/upsert?id=${data}" class="btn btn-info text-white" style="cursor:pointer; width:100px;">
//                                    <i class="far fa-edit"></i> Edit
//                                </a>
//                                <a href="/identity/account/resetPassword?code=${data}" class="btn btn-success text-white" style="cursor:pointer; width:160px;">
//                                    <i class="fas fa-lock-open"></i> Reset Password
//                                </a>
//                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onClick=Delete('/api/ownerIndex/${data}')>
//                                    <i class="far fa-trash-alt"></i> Delete
//                                </a>
//                             </div>`;
//                }, "width": "34%"
//            }
//        ],
//        language: {
//            emptyTable: "no data found."
//        },
//        width: "100%"
//    });

var dataTable;

$(document).ready(function () {
    LoadList();
});

function LoadList() {
    dataTable = $('#DT_Load').DataTable({
        "ajax": {
            "url": "/api/ownerIndex/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "firstName", "width": "11%" },
            { "data": "lastName", "width": "11%" },
            { "data": "userName", "width": "11%" },
            { "data": "emergencyContactName", "width": "11%" },
            { "data": "emergencyContactPhone", "width": "11%" },
            { "data": "ownerLots", "render": function (data) {
                return "stuff";
                }, "width": "11%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="/admin/owners/upsert?id=${data}" class="btn btn-info text-white" style="cursor:pointer; width:100px;">
                                    <i class="far fa-edit"></i> Edit
                                </a>
                                <a href="/identity/account/resetPassword?code=${data}" class="btn btn-success text-white" style="cursor:pointer; width:160px;">
                                    <i class="fas fa-lock-open"></i> Reset Password
                                </a>
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:100px;" onClick=Delete('/api/ownerIndex/${data}')>
                                    <i class="far fa-trash-alt"></i> Delete
                                </a>
                             </div>`;
                }, "width": "34%"
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    console.log("made it");
    swal({
        title: "Are you sure you want to delete?",
        text: "User will be removed!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}