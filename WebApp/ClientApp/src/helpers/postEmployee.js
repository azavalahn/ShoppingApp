
export const postEmployee =  async (payload) => {
    
   const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(payload)
        };

    try {
        const response = await fetch('http://localhost/services/api/employee', requestOptions);
        const data = await response.json();
        
    }
    catch (err) {
        console.log(err);
    }
    
}