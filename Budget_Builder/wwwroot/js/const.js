
 function categoryDeleteMessage(categoryName, section){
    if (section === "Income") {
        return `Income category "${categoryName}" deleted successfully`;
    } else{
        return `Expense category "${categoryName}" deleted successfully`;
    }
}
function deleteCategoryActivityMessage(categoryName, section) {
    if (section === "Income") {
        return `"${categoryName}" category is deleted from ${section} Section.`;
    } else {
        return `"${categoryName}" category is deleted from ${section} Section.`;
    }
}


window.constant = {
    startDateEndDateValidation : "Please select both start date and end date.",
    endDateValidation : "End date should be greater than Start date.",
    generateSuccessMessage : "Budget sheet generated successfully.",
    blueColor : "blue",
    redColor : "red",
    greenColor : "green",
    resetMessage : "The budget Sheet has been reset.",
    activityErrorMessage : "No activity found to export",
    EmptyImportValidation : "Please select a file to import.",
    importInvalidExcelMessage : "Please select a valid Excel file.",
    importInvalidDataMessage : "The selected file does not contain valid data.",
    importSuccessMessage : "Data imported from Excel file successfully",
    empryCategoryNameMessage : "Category name cannot be empty.",
    existingCategorynameMessage : "Category name Already exist.",
    categoryNameUpdateSuccessMessage : "Category name updated successfully",
    limitValueMessage : "Amount should be less than 9999999999",
    generatesheetActivityMessage: function(from, to) {
        return `Budget sheet generated for the period ${from} to ${to}`;
    },
    categoryAddActivityMessage : function(categoryName, section) {
       return  `"${categoryName}" category is Added under ${section} Section. `
    },
    AddValueMessgae : function(categoryName, value, section, month) {
        return `${value} Rs has been added to month ${month} of ${section} category "${categoryName}"`;
    },
    categoryDeleteMessage : function(categoryName, section) {
        return categoryDeleteMessage(categoryName, section);
    },
    deleteCategoryActivityMessage : function(categoryName, section) {
        return deleteCategoryActivityMessage(categoryName, section);
    },
    applyToAllActivityMessage : function(categoryName, value, section, month) {
        return`${value} Rs has been added to all months of ${section} category  "${categoryName}".`;
    },
    applyBeforeActivityMessage : function(categoryName, value, section, month) {
        return `${value} Rs has been added to all months of ${section} category "${categoryName}" before ${month}.`;
    },
    applyAfterActivityMessage : function(categoryName, value, section, month) {
        return `${value} Rs has been added to all months of ${section} category "${categoryName}" After ${month}.`;
    },
    exportMessgae(name){
        return `${name} has been Exported to excel file successfully`;
    },
    importActivityMessage : function(from, to){
        return `Data imported from excel file from ${from} to ${to}.`
    }




    

}
