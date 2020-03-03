import { Component, ElementRef, EventEmitter, forwardRef, Inject, Input, Output, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent } from '@angular/material';
import { COMMA, ENTER, SEMICOLON } from '@angular/cdk/keycodes';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { map, startWith } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-custom-chip-list',
  templateUrl: './custom-chip-list.component.html',
  styleUrls: [ './custom-chip-list.component.scss' ],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomChipListComponent),
      multi: true
    }
  ]
})
export class CustomChipListComponent implements ControlValueAccessor {
  separatorKeyCodes: number[] = [ ENTER, SEMICOLON, COMMA ];
  filteredAutocomplete: Observable<string[]>;
  chipCtrl = new FormControl();
  chips: string[] = [];

  @Input() autocompleteValues: string[];
  @Output() onNewChipSelect = new EventEmitter<string | string[]>();

  @ViewChild('chipInput', { static: false }) chipInput: ElementRef<HTMLInputElement>;
  @ViewChild('chipAutocomplete', { static: false }) matAutocomplete: MatAutocomplete;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.filteredAutocomplete = this.chipCtrl.valueChanges.pipe(
      startWith(null),
      map((skill: string | null) => skill ? this._filter(skill) : this.autocompleteValues.slice())
    );
  }

  val = ''; // this is the updated value that the class accesses

  onChange: any = () => { };
  onTouch: any = () => { };

  set value(val) {  // this value is updated by programmatic changes
    if (val !== undefined && this.val !== val) {
      this.val = val;
      this.onChange(val);
      this.onTouch(val);
    }
  }

// this method sets the value programmatically
  writeValue(value: any) {
    this.value = value;
  }

// upon UI element value changes, this method gets triggered
  registerOnChange(fn: any) {
    this.onChange = fn;
  }

// upon touching the element, this method gets triggered
  registerOnTouched(fn: any) {
    this.onTouch = fn;
  }


  addChip(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if (value.trim() && this.chips.indexOf(value.trim()) === -1) {
      this.chips.push(value.trim());
      this.onNewChipSelect.emit(this.chips);
    }

    if (input) {
      input.value = '';
    }

    this.chipCtrl.setValue(null);
  }

  removeChip(skill: string): void {
    const index = this.chips.indexOf(skill);

    if (index >= 0) {
      this.chips.splice(index, 1);
      this.onNewChipSelect.emit(this.chips);
    }
  }

  chipSelected(event: MatAutocompleteSelectedEvent): void {
    if (this.chips.indexOf(event.option.viewValue) === -1) {
      this.chips.push(event.option.viewValue);
      this.onNewChipSelect.emit(this.chips);
    }

    this.chipInput.nativeElement.value = '';
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.autocompleteValues.filter(skill => skill.toLowerCase().indexOf(filterValue) === 0);
  }
}
