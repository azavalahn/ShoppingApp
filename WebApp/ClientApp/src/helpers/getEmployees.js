export const getEmployees = async () => {
    const url = `https://localhost:7164/api/employee`;
    const response = await fetch(url);
    const data  = await response.json();
    const employees = data.map(e => {
        return {
            employeeName: e.employeeName,
            employeeTypeName: e.employeeTypeName,
            address: e.address,
            telephone: e.telephone,
            employmentDate: e.employmentDate
        }
    })
    return employees;
}