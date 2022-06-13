import { getEmployees } from '../helpers/getEmployees';
import { postEmployee } from '../helpers/postEmployee';

describe('Helpers Unit tests', () => {
    test('getEmployees should fetch data correctly ', async () => {

        const employees = await getEmployees();
        expect(JSON.stringify(employees).includes('employeeName')).toBe(true);

    });

    test('getEmployeeTypes should fetch data correctly ', async () => {

        const employeeTypes = await getEmployees();
        expect(JSON.stringify(employeeTypes).includes('name')).toBe(true);

    });

    test('postEmployee should insert data correctly ', async () => {

        var now = new Date();

        const employees = await getEmployees();
        const currentRecords = employees.length;
        
        const employee = {
            id: 0,
            name: 'Test Name ' + Math.abs(Math.floor(Math.random() * (1 - 100 + 1) + 1)),
            employeeTypeId: 1,
            telephone: '555888999',
            employmentDate: '2022-06-12T15:33:36.821Z'
        }

        const endpointPost = await postEmployee(employee);
        const employeesAfterInsert = await getEmployees();
        const newEmployeesNumber = employeesAfterInsert.length;
        expect(newEmployeesNumber).toBe(currentRecords  + 1);

    });
});