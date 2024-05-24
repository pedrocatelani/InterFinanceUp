var sidebarOpen = localStorage.getItem('sidebarOpen');
if (sidebarOpen === null) {
    sidebarOpen = false;  // Default to collapsed if there's no value in local storage
} else {
    sidebarOpen = sidebarOpen === 'true' ? true : false;
}

function setSidebar() {
    var sidebar = document.getElementById("mySidebar");
    if (sidebarOpen) {
        sidebar.style.width = "250px";
        document.getElementById("main").style.marginLeft = "250px";
        sidebar.classList.remove('collapsed');
        sidebar.classList.add('expanded');
    } else {
        sidebar.style.width = "80px";
        document.getElementById("main").style.marginLeft= "80px";
        sidebar.classList.add('collapsed');
        sidebar.classList.remove('expanded');
    }
}

function toggleNav() {
    sidebarOpen = !sidebarOpen;
    localStorage.setItem('sidebarOpen', sidebarOpen);  // Store the state in local storage
    setSidebar();
}

document.addEventListener("DOMContentLoaded", function() {
    setSidebar();  // Set the sidebar state once when the page loads
});