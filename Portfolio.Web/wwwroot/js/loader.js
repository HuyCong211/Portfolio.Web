(function () {
    const overlay = document.getElementById('loader-overlay');
    const bar = document.querySelector('.progress-inner');
    let p = 0;

    // tốc độ cập nhật nhanh hơn
    const step = setInterval(() => {
        // tăng tiến nhanh hơn, đều hơn
        p += Math.random() * 25;
        if (p >= 100) p = 100;
        bar.style.width = p + '%';

        if (p >= 100) {
            clearInterval(step);
            // giảm thời gian chờ trước khi ẩn
            setTimeout(() => {
                overlay.classList.add('hide');
                setTimeout(() => overlay.remove(), 200);
            }, 150);
        }
    }, 80); // từ 120 → 80ms

    // hiệu ứng hạt bay (particles)
    const cv = document.getElementById('particles');
    if (!cv) return;

    const ctx = cv.getContext('2d');
    let W, H;

    function resize() {
        W = cv.width = overlay.clientWidth;
        H = cv.height = overlay.clientHeight;
    }
    resize();
    window.addEventListener('resize', resize);

    const parts = Array.from({ length: 40 }, () => ({
        x: Math.random() * W,
        y: Math.random() * H,
        r: 2 + Math.random() * 3,
        vx: -1 + Math.random() * 2,
        vy: -1 + Math.random() * 2
    }));

    function tick() {
        ctx.clearRect(0, 0, W, H);
        parts.forEach(p => {
            p.x += p.vx;
            p.y += p.vy;
            if (p.x < 0 || p.x > W) p.vx *= -1;
            if (p.y < 0 || p.y > H) p.vy *= -1;
            ctx.fillStyle = 'rgba(34,197,94,.85)';
            ctx.beginPath();
            ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
            ctx.fill();
        });
        requestAnimationFrame(tick);
    }
    tick();
})();
