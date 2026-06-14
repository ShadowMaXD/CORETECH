// База данных отзывов
const reviewsData = [
    { author: "Вадим Т.", platform: "ВКонтакте", avatar: "images/reviews/2081715978.png", link: "https://vk.com/reviews-226911143" },
    { author: "Ilya M.", platform: "ВКонтакте", avatar: "images/reviews/2081715969.png", link: "https://vk.com/reviews-226911143" },
    { author: "Юлия Г.", platform: "OZON", avatar: "images/reviews/2081715957.png", link: "https://www.ozon.ru/product/sistemnyy-blok..." },
    { author: "ЦифраМаркет", platform: "Avito", avatar: "images/reviews/2081715996.png", link: "https://www.avito.ru/brands/i177752551" }
    // Вставьте остальные отзывы из исходного массива
];

function createCard(item) {
    return `
        <div class="review-card">
            <div class="review-rating">
                <span class="star-icon">★ ★ ★ ★ ★</span>
                <span class="rating-value">5.0</span>
                <span class="buyer-badge">Покупатель</span>
            </div>
            <div class="review-author">
                <span class="author-name">${item.author}</span>
                <span class="author-source">${item.platform}</span>
            </div>
            <div class="review-content">
                <img src="${item.avatar}" alt="Отзыв" class="review-img" onclick="openReviewModal('${item.avatar}')">
            </div>
            <a href="${item.link}" target="_blank" class="check-review-btn">
                Проверить отзыв
                <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                    <path d="M18 13v6a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V8a2 2 0 0 1 2-2h6"></path>
                    <polyline points="15 3 21 3 21 9"></polyline>
                    <line x1="10" y1="14" x2="21" y2="3"></line>
                </svg>
            </a>
        </div>
    `;
}

function renderReviewsPage() {
    const grid = document.getElementById('js-reviews-page-grid');
    if (!grid) return;
    grid.innerHTML = ''; 
    reviewsData.forEach(item => {
        grid.insertAdjacentHTML('beforeend', createCard(item));
    });
}

function openReviewModal(imgSrc) {
    const modal = document.getElementById('reviewModal');
    const modalImg = document.getElementById('modalImg');
    modalImg.src = imgSrc;
    modal.classList.add('active');
}

function closeReviewModal() {
    document.getElementById('reviewModal').classList.remove('active');
}

document.addEventListener('DOMContentLoaded', renderReviewsPage);