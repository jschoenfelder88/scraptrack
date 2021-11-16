// Table Sorting
// Get Value of the Rows
const getCellValue = (tr, idx) => tr.children[idx].innerText || tr.children[idx].textContent;

const comparer = (idx, asc) => (a, b) => ((v1, v2) =>
    v1 !== '' && v2 !== '' && !isNaN(v1) && !isNaN(v2) ? v1 - v2 : v1.toString().localeCompare(v2)
)(getCellValue(asc ? a : b, idx), getCellValue(asc ? b : a, idx));

// do the work of sorting. 
// note, this was a bit wonky because of how we are storing data in table body tags. 
// This is version 2.0 and should work now
document.querySelectorAll('th').forEach(th => th.addEventListener('click', (() => {
    const table = th.closest('table');
    const tbody = table.querySelector('tbody');
    Array.from(tbody.querySelectorAll('tr'))
        .sort(comparer(Array.from(th.parentNode.children).indexOf(th), this.asc = !this.asc))
        .forEach(tr => tbody.appendChild(tr));
})));


/* Modal Activation */
$(document).ready(function () {
    var btns = $(".mmodal-btn");
    var modal = $(".mmodal");
    var close = document.getElementsByClassName("close")[0];

    for (var i = 0; i < btns.length; i++) {
        btns[i].addEventListener('click', function () {
            modal[0].style.display = "block";
        });
    }

    close.addEventListener("click", function () {
        modal[0].style.display = "none";
    });

    window.addEventListener("click", function (event) {
        if (event.target == modal[0]) {
            modal[0].style.display = "none";
        }
    });
});