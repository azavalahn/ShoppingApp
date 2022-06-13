export const getEmployeeTypes = async () => {
    const url = `https://localhost:7164/api/employeeType`;
    const response = await fetch(url);
    const data  = await response.json();
    const employeeTypes = data.map(e => {
        return {
            id: e.id,
            name: e.name
        }
    })
    return employeeTypes;
}