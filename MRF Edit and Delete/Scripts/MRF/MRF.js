function Add() {


    var addObj = {
        id: $('#id').val(),
        PositionName: $('#PositionName').val(),
        Created_By: $('#MRF_Created_By').val(),
        MRF_Created_Date: $('#MRF_Created_Date').val(),
        Position_to_be_filled_before: $('#Position_to_be_filled_before').val(),
        Vacancy_For: $('input[name="radiovacancy"]:checked').val(),
        Vacancy_Type: $('input[name="vacancy"]:checked').val(),
        TerritoryHQ: $('#TerritoryHQ').val(),
        DivisionName: $('#DivisionName').val(),
        Min_Yrs: $('#Min_yrs').val(),
        Max_yrs: $('#Max_yrs').val(),
        MaxCTC: $('#MaxCTC').val(),
        MinCTC: $('#MinCTC').val(),
        Additional_Requirement: $('#Additional_Requirement').val(),

    };

    $.ajax({
        url: "/MRF/Add",
        data: JSON.stringify(addObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null || data == 1) {
                $('#result').html('Record Saved Successfully!');
             
            }
            else {
                alert('Error in save!');
            }

        }

    });
}

function MRF() {
    window.location = "/User/UserIndex";
}

