// Task Management
class TaskManager {
    constructor() {
        this.tasks = [];
        this.loadTasks();
    }

    // Add new task
    addTask(text) {
        const task = {
            id: Date.now(),
            text: text,
            status: 'todo',
            createdAt: new Date().toLocaleString()
        };
        this.tasks.push(task);
        this.saveTasks();
        return task;
    }

    // Delete task
    deleteTask(id) {
        this.tasks = this.tasks.filter(task => task.id !== id);
        this.saveTasks();
    }

    // Update task status
    updateTaskStatus(id, newStatus) {
        const task = this.tasks.find(t => t.id === id);
        if (task) {
            task.status = newStatus;
            this.saveTasks();
        }
    }

    // Get tasks by status
    getTasksByStatus(status) {
        return this.tasks.filter(task => task.status === status);
    }

    // Save to localStorage
    saveTasks() {
        localStorage.setItem('tasks', JSON.stringify(this.tasks));
    }

    // Load from localStorage
    loadTasks() {
        const saved = localStorage.getItem('tasks');
        this.tasks = saved ? JSON.parse(saved) : [];
    }

    // Clear all tasks
    clearAllTasks() {
        this.tasks = [];
        this.saveTasks();
    }

    // Export tasks as JSON
    exportTasks() {
        return JSON.stringify(this.tasks, null, 2);
    }
}

// Initialize task manager
const taskManager = new TaskManager();

// DOM Elements
const taskInput = document.getElementById('taskInput');
const addBtn = document.getElementById('addBtn');
const clearBtn = document.getElementById('clearBtn');
const exportBtn = document.getElementById('exportBtn');
const columns = document.querySelectorAll('.droppable');

// Render tasks
function renderTasks() {
    // Clear all columns
    columns.forEach(column => column.innerHTML = '');

    // Render tasks in their respective columns
    const statuses = ['todo', 'progress', 'done'];
    statuses.forEach(status => {
        const tasks = taskManager.getTasksByStatus(status);
        const column = document.getElementById(`${status}-column`);

        if (tasks.length === 0) {
            column.innerHTML = '<div class="empty-message">No tasks yet</div>';
        } else {
            tasks.forEach(task => {
                const taskEl = createTaskElement(task);
                column.appendChild(taskEl);
            });
        }
    });
}

// Create task element
function createTaskElement(task) {
    const div = document.createElement('div');
    div.className = 'task';
    div.draggable = true;
    div.dataset.id = task.id;

    const statusText = {
        todo: '📋 To Do',
        progress: '⏳ In Progress',
        done: '✅ Done'
    };

    div.innerHTML = `
        <div class="task-content">
            <div class="task-text">${escapeHtml(task.text)}</div>
            <div class="task-status">${statusText[task.status]}</div>
        </div>
        <button class="delete-btn">✕</button>
    `;

    // Delete button
    div.querySelector('.delete-btn').addEventListener('click', (e) => {
        e.stopPropagation();
        taskManager.deleteTask(task.id);
        renderTasks();
    });

    // Drag events
    div.addEventListener('dragstart', handleDragStart);
    div.addEventListener('dragend', handleDragEnd);

    return div;
}

// Drag and drop handlers
let draggedElement = null;

function handleDragStart(e) {
    draggedElement = this;
    this.classList.add('dragging');
    e.dataTransfer.effectAllowed = 'move';
}

function handleDragEnd(e) {
    this.classList.remove('dragging');
}

// Column drag over handlers
columns.forEach(column => {
    column.addEventListener('dragover', (e) => {
        e.preventDefault();
        e.dataTransfer.dropEffect = 'move';
        column.classList.add('drag-over');
    });

    column.addEventListener('dragleave', () => {
        column.classList.remove('drag-over');
    });

    column.addEventListener('drop', (e) => {
        e.preventDefault();
        column.classList.remove('drag-over');

        if (draggedElement) {
            const taskId = parseInt(draggedElement.dataset.id);
            const newStatus = column.dataset.status;
            taskManager.updateTaskStatus(taskId, newStatus);
            renderTasks();
        }
    });
});

// Add task
function addNewTask() {
    const text = taskInput.value.trim();
    if (text) {
        taskManager.addTask(text);
        taskInput.value = '';
        renderTasks();
        taskInput.focus();
    }
}

addBtn.addEventListener('click', addNewTask);

// Enter key to add task
taskInput.addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        addNewTask();
    }
});

// Clear all tasks
clearBtn.addEventListener('click', () => {
    if (confirm('Are you sure you want to delete all tasks?')) {
        taskManager.clearAllTasks();
        renderTasks();
    }
});

// Export tasks
exportBtn.addEventListener('click', () => {
    const data = taskManager.exportTasks();
    const blob = new Blob([data], { type: 'application/json' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = `tasks-${new Date().toISOString().slice(0, 10)}.json`;
    a.click();
    URL.revokeObjectURL(url);
});

// Escape HTML to prevent XSS
function escapeHtml(text) {
    const map = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;',
        '"': '&quot;',
        "'": '&#039;'
    };
    return text.replace(/[&<>"']/g, m => map[m]);
}

// Initial render
renderTasks();
focus();
