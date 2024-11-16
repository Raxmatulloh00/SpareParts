var count = 0;
function addSwipeListener(productId, dotNetObjRef) {
    const element = document.getElementById(productId);

    let touchStartX = 0;
    let touchStartY = 0;
    let touchEndX = 0;
    let touchEndY = 0;

    element.addEventListener('touchstart', (e) => {
        touchStartX = e.touches[0].clientX;
        touchStartY = e.touches[0].clientY;
    });

    element.addEventListener('touchend', (e) => {
        touchEndX = e.changedTouches[0].clientX;
        touchEndY = e.changedTouches[0].clientY;
        const deltaX = touchEndX - touchStartX;
        const deltaY = touchEndY - touchStartY;

        // Check for swipe direction
        if (Math.abs(deltaX) > Math.abs(deltaY)) {
            if (deltaX < 0) { 
                dotNetObjRef.invokeMethodAsync('HandleSwipe', productId, 'left');
            } else if (deltaX > 0) {
                dotNetObjRef.invokeMethodAsync('HandleSwipe', productId, 'right');
            }
        }
    });
}