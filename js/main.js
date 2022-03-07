const btn = document.querySelector('#menu-btn');
const menu= document.querySelector('#sidebar');
btn.addEventListener('click',e=>{
    menu.classList.toggle("menu-expanded");
    menu.classList.toggle("menu-collapsed");
});