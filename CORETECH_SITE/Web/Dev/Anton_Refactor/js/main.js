document.addEventListener('DOMContentLoaded', () => {
    // 1. Звездный фон и гироскоп
    const space = document.getElementById('js-stars-space');
    if (space) {
        const maxStars = 30;
        const starsArray = [];
        function createStar() {
            const star = document.createElement('div');
            star.classList.add('dynamic-star');
            const speed = Math.random() * 3 + 2.5;
            const delay = Math.random() * 6;
            const startLeft = Math.random() * 160 - 50;
            const scaleX = Math.random() * 0.6 + 0.7;
            const scaleY = Math.random() * 0.5 + 0.8;
            const depth = Math.random() * 15 + 5;
            star.style.left = `${startLeft}%`;
            star.style.top = `-100px`;
            const animName = `fall-${Math.floor(Math.random() * 1000000)}`;
            const keyframes = `@keyframes ${animName} { 0% { transform: translateY(0) translateX(0) rotate(-45deg) scale(${scaleX}, ${scaleY}); opacity: 0; } 10% { opacity: 1; } 85% { opacity: 1; } 100% { transform: translateY(120vh) translateX(120vh) rotate(-45deg) scale(${scaleX}, ${scaleY}); opacity: 0; } }`;
            const styleSheet = document.createElement('style');
            styleSheet.innerText = keyframes;
            document.head.appendChild(styleSheet);
            star.style.animation = `${animName} ${speed}s linear ${delay}s infinite`;
            space.appendChild(star);
            starsArray.push({ element: star, depth: depth, baseLeft: startLeft });
        }
        for (let i = 0; i < maxStars; i++) createStar();
        
        let mouseX = 0, mouseY = 0;
        window.addEventListener('mousemove', (e) => {
            mouseX = (e.clientX / window.innerWidth) - 0.5;
            mouseY = (e.clientY / window.innerHeight) - 0.5;
            starsArray.forEach(star => {
                star.element.style.marginLeft = `${mouseX * star.depth}px`;
                star.element.style.marginTop = `${mouseY * star.depth}px`;
            });
        });
    }

    // 2. Шапка (скролл)
    const header = document.querySelector('.site-header');
    window.addEventListener('scroll', () => {
        if (window.scrollY > 50) header.classList.add('scrolled');
        else header.classList.remove('scrolled');
    });

    // 3. Мобильное меню
    const mobileToggle = document.getElementById('js-mobile-toggle');
    const mobileMenu = document.getElementById('js-mobile-menu');
    function toggleMobileMenu() {
        mobileToggle.classList.toggle('active');
        const isActive = mobileMenu.classList.toggle('active');
        document.body.style.overflow = isActive ? 'hidden' : '';
    }
    if (mobileToggle && mobileMenu) {
        mobileToggle.addEventListener('click', toggleMobileMenu);
        mobileMenu.querySelectorAll('.mobile-menu-link, .mobile-menu-action-btn').forEach(link => {
            link.addEventListener('click', () => {
                if (mobileMenu.classList.contains('active')) toggleMobileMenu();
            });
        });
    }

    // 4. Печатная машинка (конфигурации)
    const builds = [
        { cpu: "Ryzen 7 7800X3D", gpu: "NVIDIA RTX 5070 12Гб", ram: "32GB DDR5 6000MHz", cooling: "Воздушное охлаждение" },
        { cpu: "Core i5-13600K", gpu: "RTX 4060 Ti 16GB", ram: "16GB DDR4 3600MHz", cooling: "СЖО 240mm" },
        { cpu: "Ryzen 5 7600X", gpu: "Radeon RX 7800 XT", ram: "32GB DDR5 5200MHz", cooling: "DeepCool AK620" }
    ];
    let currentBuildIndex = 0;
    async function typeText(el, text) {
        for (let i = 0; i <= text.length; i++) {
            el.textContent = text.substring(0, i);
            await new Promise(res => setTimeout(res, 40));
        }
    }
    async function eraseText(el) {
        let text = el.textContent;
        for (let i = text.length; i >= 0; i--) {
            el.textContent = text.substring(0, i);
            await new Promise(res => setTimeout(res, 20));
        }
    }
    async function updateBuilds() {
        const specs = [ { id: 'cpu-val', key: 'cpu' }, { id: 'gpu-val', key: 'gpu' }, { id: 'ram-val', key: 'ram' }, { id: 'cool-val', key: 'cooling' } ];
        while (true) {
            const build = builds[currentBuildIndex];
            await Promise.all(specs.map(spec => typeText(document.getElementById(spec.id), build[spec.key])));
            await new Promise(res => setTimeout(res, 2500));
            await Promise.all(specs.map(spec => eraseText(document.getElementById(spec.id))));
            currentBuildIndex = (currentBuildIndex + 1) % builds.length;
        }
    }
    const cpuEl = document.getElementById('cpu-val');
    if(cpuEl) updateBuilds();

    // 5. Рендер каталога (Укороченный пример данных для наглядности)
    const myComputers = [
        { name: "CORE ALL-INCLUSIVE", isHit: false, image: "images/catalog/comp8.png", fpsNumber: "145+ FPS", fpsBarWidth: "45%", fpsModal: {'CS2': '321 FPS'}, cpu: "Ryzen 7 9800X3D", gpu: "RTX 5080 16Гб", ram: "32Гб DDR5", cooling: "GF Eskimo", statusClass: "on-order", statusText: "Под заказ", price: "от 279 990 ₽", specsModal: {'Накопитель': '1Тб'} }
        // Добавьте остальные ПК из старого index.html
    ];
    const grid = document.getElementById('js-catalog-grid');
    if (grid) {
        grid.innerHTML = '';
        myComputers.forEach(pc => {
            const badge = pc.isHit ? `<div class="badge-hit">ХИТ</div>` : '';
            const fpsDataStr = JSON.stringify(pc.fpsModal).replace(/"/g, '&quot;');
            const specsDataStr = JSON.stringify(pc.specsModal).replace(/"/g, '&quot;');
            grid.insertAdjacentHTML('beforeend', `
                <div class="product-card">
                    ${badge}
                    <div class="product-image"><img src="${pc.image}"></div>
                    <div class="product-name">${pc.name}</div>
                    <div class="fps-widget" onclick="openFpsModal('${pc.name}', ${fpsDataStr})">
                        <div class="fps-inner"><div class="fps-header"><span>FPS</span><span class="fps-number">${pc.fpsNumber}</span></div></div>
                    </div>
                    <div class="product-price">${pc.price}</div>
                    <button class="btn-card" onclick="openSpecsModal(this, ${specsDataStr})">Подробнее</button>
                    <button class="g-btn-buy" onclick="gOpenBuy(this)">Купить</button>
                </div>
            `);
        });
    }

    // 6. Модальное окно лидогенерации
    const coreModal = document.getElementById('js-core-modal');
    const closeBtn = document.getElementById('js-modal-close');
    const openButtons = document.querySelectorAll('.hero-action-btn, .configurator-action-btn, .mobile-menu-action-btn, .btn-purple, .btn-consult');

    if (coreModal) {
        function openCoreModal(e) {
            e.preventDefault(); 
            coreModal.style.display = 'flex'; 
            setTimeout(() => coreModal.classList.add('is-active'), 10);
            document.body.style.overflow = 'hidden';
        }
        function closeCoreModal() {
            coreModal.classList.remove('is-active');
            document.body.style.overflow = '';
            setTimeout(() => { if (!coreModal.classList.contains('is-active')) coreModal.style.display = 'none'; }, 300);
        }
        openButtons.forEach(btn => btn.addEventListener('click', openCoreModal));
        if (closeBtn) closeBtn.addEventListener('click', closeCoreModal);
        coreModal.addEventListener('click', (e) => { if (e.target === coreModal) closeCoreModal(); });
    }
});

// Глобальные функции для каталога
const pcDataStorage = {};
function openFpsModal(pcName, games) { /* Логика из старого файла */ }
function openSpecsModal(btn, extraSpecs) { /* Логика из старого файла */ }
function closeModal() { document.getElementById('infoModal').style.display = 'none'; }
function gOpenBuy(btn) { /* Логика генерации текста заказа */ }
function gCloseBuy() { document.getElementById('gBuyModal').style.display = 'none'; }
function gCopyText() { /* Логика копирования буфера обмена */ }
function acceptCookies() { document.getElementById('cookieNotice').classList.remove('show'); localStorage.setItem('cookieConsent', 'true'); }
setTimeout(() => { if(!localStorage.getItem('cookieConsent')) { const n = document.getElementById('cookieNotice'); if(n) n.classList.add('show'); }}, 1500);