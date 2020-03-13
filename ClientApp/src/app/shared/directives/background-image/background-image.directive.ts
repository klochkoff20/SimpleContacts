import { AfterViewInit, Directive, ElementRef, Input, OnChanges, Renderer2, SimpleChanges } from '@angular/core';

@Directive({
  selector: '[appBackgroundImage]',
  /* tslint:disable */
  host: {
    '[style.background-image]': '"url("+ appBackgroundImage + ")"',
    '[style.background-size]': 'backgroundSize || "cover"',
    '[style.background-repeat]': '"no-repeat"',
    '[style.background-position]': '"center center"'
  }
  /* tslint:enable */
})

export class BackgroundImageDirective implements OnChanges, AfterViewInit {
  private el: HTMLElement;

  @Input() appBackgroundImage: any;
  @Input() backgroundSize: any;

  defaultImageUrl = '/assets/images/default-image.jpg';

  constructor(private renderer: Renderer2, private elRef: ElementRef) {
    this.el = this.elRef.nativeElement;
  }

  ngAfterViewInit() {
    this.setBackgroundImage();
  }

  ngOnChanges(changes: SimpleChanges) {
    changes['appBackgroundImage'] && this.setBackgroundImage();
  }

  setBackgroundImage() {
    this.renderer.setStyle(
      this.el,
      'backgroundImage',
      `url(${(this.appBackgroundImage) ? this.appBackgroundImage : this.defaultImageUrl})`);
  }
}
