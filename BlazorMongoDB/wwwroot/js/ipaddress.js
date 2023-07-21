window.ipAddressInterop = {
    getClientIPAddress: function () {
        return new Promise((resolve, reject) => {
            fetch('https://api.ipify.org?format=json')
                .then(response => response.json())
                .then(data => resolve(data.ip))
                .catch(error => reject(error));
        });
    }
};

