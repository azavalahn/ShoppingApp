import { render } from '@testing-library/react';
import { EmployeeGrid } from '../components/EmployeeGrid';
import { EmployeeRegistration } from '../components/EmployeeRegistration';
import React from 'react';

describe('Components Unit Test', () => {

    test('Employee Grid component should render correctly', () => {

        const { getByText } = render(<EmployeeGrid />);
        expect(getByText('Employee List')).toBeInTheDocument();
    });

    test('Employee Registration component should render correctly', () => {

        const { getByText } = render(<EmployeeRegistration />);
        expect(getByText('Employee Registration')).toBeInTheDocument();
    });
})