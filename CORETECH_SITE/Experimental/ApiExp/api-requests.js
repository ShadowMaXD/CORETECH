const BASE_URL = 'https://jsonplaceholder.typicode.com/posts';

// Вспомогательная функция для красивого вывода JSON в блок <pre>
function renderResult(elementId, data) {
    document.getElementById(elementId).textContent = JSON.stringify(data, null, 2);
}

// --- 1. GET ЗАПРОС ---
document.getElementById('btn-get').addEventListener('click', async () => {
    document.getElementById('output-get').textContent = 'Загрузка...';
    try {
        // По умолчанию fetch делает именно GET-запрос
        const response = await fetch(`${BASE_URL}/1`); 
        const data = await response.json();
        renderResult('output-get', data);
    } catch (err) {
        renderResult('output-get', { error: err.message });
    }
});

// --- 2. POST ЗАПРОС ---
document.getElementById('btn-post').addEventListener('click', async () => {
    document.getElementById('output-post').textContent = 'Отправка...';
    
    const titleInput = document.getElementById('post-title').value;
    const bodyInput = document.getElementById('post-body').value;

    try {
        const response = await fetch(BASE_URL, {
            method: 'POST', 
            body: JSON.stringify({
                title: titleInput,
                body: bodyInput,
                userId: 1
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8', 
            },
        });
        const data = await response.json();
        renderResult('output-post', data); 
    } catch (err) {
        renderResult('output-post', { error: err.message });
    }
});

// --- 3. PUT ЗАПРОС ---
document.getElementById('btn-put').addEventListener('click', async () => {
    document.getElementById('output-put').textContent = 'Обновление...';
    try {
        const response = await fetch(`${BASE_URL}/1`, { 
            method: 'PUT', 
            body: JSON.stringify({
                id: 1,
                title: 'Обновленный заголовок',
                body: 'Этот текст был полностью перезаписан методом PUT.',
                userId: 1,
            }),
            headers: {
                'Content-type': 'application/json; charset=UTF-8',
            },
        });
        const data = await response.json();
        renderResult('output-put', data);
    } catch (err) {
        renderResult('output-put', { error: err.message });
    }
});

// --- 4. DELETE ЗАПРОС ---
document.getElementById('btn-delete').addEventListener('click', async () => {
    document.getElementById('output-delete').textContent = 'Удаление...';
    try {
        const response = await fetch(`${BASE_URL}/1`, {
            method: 'DELETE', 
        });
        
        if (response.ok) {
            renderResult('output-delete', { success: true, message: "Запись с ID 1 успешно удалена!" });
        }
    } catch (err) {
        renderResult('output-delete', { error: err.message });
    }
});