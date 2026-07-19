# Drag & Drop To-Do List App 📝

A beautiful, fully functional to-do list application with drag-and-drop functionality and local storage.

## ✨ Features

- **Drag & Drop**: Move tasks between columns (To Do → In Progress → Done)
- **Local Storage**: All tasks saved automatically to your browser
- **Add Tasks**: Simple input field with Enter key support
- **Delete Tasks**: Remove individual tasks with one click
- **Export Tasks**: Download your tasks as JSON
- **Clear All**: Remove all tasks at once (with confirmation)
- **Responsive Design**: Works on desktop and mobile
- **Beautiful UI**: Modern gradient design with smooth animations

## 🚀 How to Use

### Local Setup
1. Clone the repository
2. Open `todo-app/index.html` in your browser
3. Start adding tasks!

### Online (itch.io)
1. Build the app (it's already ready - just HTML/CSS/JS)
2. Upload `todo-app/` folder to itch.io
3. Set as HTML5 game
4. Share your link!

## 📋 Task Management

### Adding a Task
- Type in the input field
- Press Enter or click "Add Task"
- Task appears in the "To Do" column

### Moving Tasks
- Click and drag any task card
- Drop it into a new column (To Do, In Progress, or Done)
- Status updates automatically
- Changes saved to local storage instantly

### Deleting a Task
- Click the ✕ button on any task card
- Task is removed immediately

### Exporting Tasks
- Click "Export Tasks"
- Downloads JSON file with all your tasks
- Perfect for backup or sharing

## 💾 Local Storage

All tasks are automatically saved to your browser's local storage:
- No server needed
- Works offline
- Data persists between sessions
- Clear browser data to reset

## 🎨 Customization

### Change Colors
Edit `styles.css`:
```css
body {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}
```

### Change Column Names
Edit `index.html` - change the `<h2>` text in each column

## 📱 Mobile Responsive
- Works perfectly on phones and tablets
- Touch-friendly drag and drop
- Single column layout on small screens

## 🔒 Security
- Input sanitization to prevent XSS attacks
- Safe JSON parsing
- No external dependencies

## 📦 File Structure
```
todo-app/
├── index.html      # Main HTML structure
├── styles.css      # Styling and animations
├── script.js       # Task logic and drag-drop
└── README.md       # This file
```

## 🌐 Deploy to itch.io

1. Upload entire `todo-app/` folder
2. Set as "HTML5" game
3. Configure:
   - Embed options: Fullscreen
   - Viewport: 1280 x 720 (or your preference)
4. Publish!

## 💡 Tips

- Use "To Do" for tasks you haven't started
- Use "In Progress" for tasks you're working on
- Use "Done" for completed tasks
- Export regularly for backup
- Works best in Chrome, Firefox, Safari, Edge

## 🐛 Troubleshooting

### Tasks not saving?
- Check if local storage is enabled in browser
- Try a different browser
- Clear browser cache and reload

### Drag and drop not working?
- Ensure JavaScript is enabled
- Try a different browser
- Make sure you're using the latest version

## 🎉 Have fun organizing!
