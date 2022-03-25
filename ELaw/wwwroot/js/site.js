// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openErrorModal(strMessage) {
    var myDiv = document.getElementById("MyModalErrorAlertBody");
    myDiv.innerHTML = strMessage;
    $('#myModalError').modal('show');
}

function openSuccessModal(strMessage) {
    var myDiv = document.getElementById("MyModalSuccessAlertBody");
    myDiv.innerHTML = strMessage;
    $('#myModalSuccess').modal('show');
}

// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function DeleteItem(btn) {
    var table = document.getElementById('ReferredCasesTable');
    var rows = table.getElementsByTagName('tr');
    if (rows.length == 2) {
        alert("This Row Cannot Be Deleted");
        return;
    }
    var btnIdx = btn.id.replaceAll('btnremove-', '');
    var idofIsDeleted = btnIdx + "__IsDeleted";
    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
    document.getElementById(hidIsDelId).value = "true";

    $(btn).closest('tr').hide();

}
function AddItem(btn) {

    var table = document.getElementById('ReferredCasesTable');
    var rows = table.getElementsByTagName('tr');

    var rowOuterHtml = rows[rows.length - 1].outerHTML;

    var lastrowIdx = rows.length - 2;

    var nextrowIdx = eval(lastrowIdx) + 1;

    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

    var newRow = table.insertRow();
    newRow.innerHTML = rowOuterHtml;

    var x = document.getElementsByTagName('input');
    for (var cnt = 0; cnt < x.length; cnt++) {
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
    }
}

function DeleteItemLegislation(btn) {
    var table1 = document.getElementById('ReferredLegislationsTable');
    var rows1 = table1.getElementsByTagName('tr');
    if (rows1.length == 2) {
        alert("This Row Cannot Be Deleted");
        return;
    }
    var btnIdx1 = btn.id.replaceAll('btnremove-', '');
    var idofIsDeleted1 = btnIdx1 + "__IsDeleted";
    var hidIsDelId1 = document.querySelector("[id$='" + idofIsDeleted1 + "']").id;
    document.getElementById(hidIsDelId1).value = "true";

    $(btn).closest('tr').hide();

}
function AddItemLegislation(btn) {

    var table1 = document.getElementById('ReferredLegislationsTable');
    var rows1 = table1.getElementsByTagName('tr');

    var rowOuterHtml1 = rows1[rows1.length - 1].outerHTML;

    var lastrowIdx1 = rows1.length - 2;

    var nextrowIdx1 = eval(lastrowIdx1) + 1;

    rowOuterHtml1 = rowOuterHtml1.replaceAll('_' + lastrowIdx1 + '_', '_' + nextrowIdx1 + '_');
    rowOuterHtml1 = rowOuterHtml1.replaceAll('[' + lastrowIdx1 + ']', '[' + nextrowIdx1 + ']');
    rowOuterHtml1 = rowOuterHtml1.replaceAll('-' + lastrowIdx1, '-' + nextrowIdx1);

    var newRow = table1.insertRow();
    newRow.innerHTML = rowOuterHtml1;

    var x = document.getElementsByTagName('input');
    for (var cnt = 0; cnt < x.length; cnt++) {
        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
            x[cnt].value = '';
    }
}

//function DeleteItemAppellant(btn) {
//    var table = document.getElementById('AppellantsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemAppellant(btn) {
//    var table = document.getElementById('AppellantsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemApplicant(btn) {
//    var table = document.getElementById('ApplicantsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemApplicant(btn) {
//    var table = document.getElementById('ApplicantsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemClaimant(btn) {
//    var table = document.getElementById('ClaimantsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemClaimant(btn) {
//    var table = document.getElementById('ClaimantsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemPlaintiff(btn) {
//    var table = document.getElementById('PlaintiffsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemPlaintiff(btn) {
//    var table = document.getElementById('PlaintiffsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemRespondent(btn) {
//    var table = document.getElementById('RespondentsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemRespondent(btn) {
//    var table = document.getElementById('RespondentsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemDefendent(btn) {
//    var table = document.getElementById('DefendentsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemDefendent(btn) {
//    var table = document.getElementById('DefendentsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemThirdParty(btn) {
//    var table = document.getElementById('ThirdPartiesTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemThirdParty(btn) {
//    var table = document.getElementById('ThirdPartiesTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
////}

//function DeleteItemLiquidator(btn) {
//    var table = document.getElementById('LiquidatorsTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemLiquidator(btn) {
//    var table = document.getElementById('LiquidatorsTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}

//function DeleteItemCompany(btn) {
//    var table = document.getElementById('CompaniesTable');
//    var rows = table.getElementsByTagName('tr');
//    if (rows.length == 2) {
//        alert("This Row Cannot Be Deleted");
//        return;
//    }
//    var btnIdx = btn.id.replaceAll('btnremove-', '');
//    var idofIsDeleted = btnIdx + "__IsDeleted";
//    var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;
//    document.getElementById(hidIsDelId).value = "true";

//    $(btn).closest('tr').hide();

//}
//function AddItemCompany(btn) {
//    var table = document.getElementById('CompaniesTable');
//    var rows = table.getElementsByTagName('tr');

//    var rowOuterHtml = rows[rows.length - 1].outerHTML;

//    var lastrowIdx = rows.length - 2;

//    var nextrowIdx = eval(lastrowIdx) + 1;

//    rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
//    rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
//    rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

//    var newRow = table.insertRow();
//    newRow.innerHTML = rowOuterHtml;

//    var x = document.getElementsByTagName('input');
//    for (var cnt = 0; cnt < x.length; cnt++) {
//        if (x[cnt].type == "text" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//        if (x[cnt].type == "number" && x[cnt].id.indexOf('_' + nextrowIdx + '_') > 0)
//            x[cnt].value = '';
//    }
//}