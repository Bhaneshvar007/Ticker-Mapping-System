
function exportTableToExcel(tableId, filename = 'ExportedData.xlsx') {
    var table = document.querySelector(tableId);
    if (!table) {
        alert("Table not found: " + tableId);
        return;
    }
    var wb = XLSX.utils.table_to_book(table, { sheet: "Sheet1" });
    XLSX.writeFile(wb, filename);
}