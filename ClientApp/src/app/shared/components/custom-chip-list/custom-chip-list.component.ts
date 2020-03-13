import { AfterViewInit, Component, ElementRef, EventEmitter, forwardRef, Inject, Input, Output, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatAutocomplete, MatAutocompleteSelectedEvent, MatChipInputEvent } from '@angular/material';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { COMMA, ENTER, SEMICOLON } from '@angular/cdk/keycodes';
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
export class CustomChipListComponent implements ControlValueAccessor, AfterViewInit {
  separatorKeyCodes: number[] = [ ENTER, SEMICOLON, COMMA ];
  filteredAutocomplete: Observable<string[]>;
  chipCtrl = new FormControl();

  @Input() chips: string[] = [];
  @Input() autocompleteValues: string[];
  @Input() placeholder: string;
  @Output() NewChipSelect = new EventEmitter<string | string[]>();

  @ViewChild('chipInput', { static: false }) chipInput: ElementRef<HTMLInputElement>;
  @ViewChild('chipAutocomplete', { static: false }) matAutocomplete: MatAutocomplete;

  onTouch: any = () => {};
  onChange: any = () => {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {
    this.filteredAutocomplete = this.chipCtrl.valueChanges.pipe(
      startWith(null),
      map((skill: string | null) => skill ? this._filter(skill) : this.autocompleteValues.slice())
    );
  }

  ngAfterViewInit() {
    this.onTouch(this.chips);
    this.onChange(this.chips);
  }

  writeValue(value: any) {
    if (value !== '' && value !== null) {
      this.chips.push(value);
    }
  }

  registerOnTouched(fn: any) {
    this.onTouch = fn;
  }

  registerOnChange(fn: any) {
    this.onChange = fn;
  }

  addChip(event: MatChipInputEvent): void {
    const input = event.input;
    const value = event.value;

    if (value.trim() && this.chips.indexOf(value.trim()) === -1) {
      this.writeValue(value.trim());
      this.onTouch(this.chips);
      this.onChange(this.chips);
      this.NewChipSelect.emit(this.chips.toString());
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
      this.onTouch(this.chips);
      this.onChange(this.chips);
      this.NewChipSelect.emit(this.chips.toString());
    }
  }

  chipSelected(event: MatAutocompleteSelectedEvent): void {
    if (this.chips.indexOf(event.option.viewValue) === -1) {
      this.chips.push(event.option.viewValue);
      this.onTouch(this.chips);
      this.onChange(this.chips);
      this.NewChipSelect.emit(this.chips.toString());
    }

    this.chipInput.nativeElement.value = '';
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.autocompleteValues.filter(skill => skill.toLowerCase().indexOf(filterValue) === 0);
  }
}
