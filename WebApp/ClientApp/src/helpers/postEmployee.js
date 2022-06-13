
export const postEmployee =  async (payload) => {
    console.log('El payload es:', payload);
    console.log('el string payload es:', JSON.stringify(payload));
   const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        };

    try {
        const response = await fetch('https://localhost:7164/api/employee', requestOptions);
        const data = await response.json();
        
    }
    catch (err) {
        console.log(err);
    }
    
}