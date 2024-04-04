function downloadFile(fileName, data) {
    const blob = new Blob([data], { type: 'text/plain' }); // Replace 'text/plain' with the appropriate content type
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = fileName;
    link.click();
    window.URL.revokeObjectURL(url);
    Console.log("It shoul work.")
}