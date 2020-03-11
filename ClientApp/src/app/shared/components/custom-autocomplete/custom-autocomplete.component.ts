import { Component, forwardRef, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatAutocompleteSelectedEvent } from '@angular/material';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-custom-autocomplete',
  templateUrl: './custom-autocomplete.component.html',
  styleUrls: ['./custom-autocomplete.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomAutocompleteComponent),
      multi: true
    }
  ]
})
export class CustomAutocompleteComponent implements ControlValueAccessor, OnInit {
  myControl = new FormControl();
  filteredAutocomplete: Observable<string[]>;

  @Input() value: string;
  @Input() autocompleteValues: string[];
  @Input() placeholder: string;

  onChange: any = () => { };
  onTouch: any = () => { };

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit() {
    this.filteredAutocomplete = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
    );

    this.myControl.setValue(this.value);
  }

  onValueChanged(event) {
    this.writeValue(event.target.value);
  }

  writeValue(value: any) {
    if (value !== '') {
      this.value = value;
      this.onChange(this.value);
    }
  }

  registerOnChange(fn: any) {
    this.onChange = fn;
  }

  registerOnTouched(fn: any) {
    this.onTouch = fn;
  }

  onValueSelected(event: MatAutocompleteSelectedEvent): void {
      this.onChange(this.value);
      this.onTouch(this.value);
      this.writeValue(event.option.value);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.autocompleteValues.filter(filter => filter.toLowerCase().includes(filterValue));
  }
}
