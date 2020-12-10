export class Statistics {
    id: number;
    dateTime: Date;
    temperature: number;
    moisturePercentage: number;
    weight: number;
    location: string;

    constructor () {
        this.id = 0;
        this.dateTime = new Date();
        this.temperature = 0;
        this.moisturePercentage = 0;
        this.weight = 0;
        this.location = '';
    }
}