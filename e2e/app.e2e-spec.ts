import { WhatechChallengePage } from './app.po';

describe('whatech-challenge App', () => {
  let page: WhatechChallengePage;

  beforeEach(() => {
    page = new WhatechChallengePage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
